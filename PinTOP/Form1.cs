using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

// <!-- Publish as single Exe command -->
// <!-- dotnet publish -r win-x64 --self-contained=false /p:PublishSingleFile=true -->
// <!-- https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish -->
// Winform application not support Trim command.

namespace PinTOP;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private const int GW_HWNDNEXT = 2;
    private const int SWP_NOMOVE = 0x0002;
    private const int SWP_NOSIZE = 0x0001;
    private const int SWP_HIDEWINDOW = 0x0080;
    private const int SWP_SHOWWINDOW = 0x0040;
    private const int WS_EX_TOPMOST = 0x0008;

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("user32.dll")]
    private static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    private const int GW_OWNER = 4;
    private const int GW_CHILD = 5;

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindow(IntPtr hWnd, int wCmd);

    [DllImport("user32.dll")]
    private static extern IntPtr GetParent(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    private const int GWL_EXSTYLE = -20;

    private List<WindowItem> _windowList = new List<WindowItem>();


    private void Form1_Load(object sender, EventArgs e)
    {
        RefreshWindowList();
    }

    private void RefreshWindowList()
    {
        _windowList.Clear();
        IntPtr hwnd = Process.GetCurrentProcess().MainWindowHandle; // 获取当前进程的主窗口句柄
        while ((hwnd = GetWindow(hwnd, GW_HWNDNEXT)) != IntPtr.Zero)
        {
            if (IsWindowVisible(hwnd))
            {
                uint pid = 0;
                GetWindowThreadProcessId(hwnd, out pid);
                // if (pid == Process.GetCurrentProcess().Id) // 只添加当前进程的窗口句柄
                // {
                    string title = GetWindowTitle(hwnd);
                    if (!string.IsNullOrEmpty(title))
                    {
                        _windowList.Add(new WindowItem(title, hwnd));
                    }
                // }
            }
        }

        // Set the data binding properties explicitly
        comboBox1.DataSource = null;
        comboBox1.DataSource = _windowList;
        comboBox1.DisplayMember = "Title";
        comboBox1.ValueMember = "Handle";
    }

    private string GetWindowTitle(IntPtr hwnd)
    {
        const int nChars = 256;
        StringBuilder builder = new StringBuilder(nChars);
        if (GetWindowText(hwnd, builder, nChars) > 0)
        {
            return builder.ToString();
        }
        return null;
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        RefreshWindowList();
    }

    private void btnPin_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedValue != null)
        {
            PinWindow((IntPtr)comboBox1.SelectedValue);
        }
    }

    private void btnUnpin_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedValue != null)
        {
            UnpinWindow((IntPtr)comboBox1.SelectedValue);
        }
    }

    private void PinWindow(IntPtr hWnd)
    {
        SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_TOPMOST);
        SetWindowPos(hWnd, new IntPtr(-1), 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
    }

    private void UnpinWindow(IntPtr hWnd)
    {
        SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) & ~WS_EX_TOPMOST);
        SetWindowPos(hWnd, new IntPtr(1), 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_HIDEWINDOW);
        SetWindowPos(hWnd, new IntPtr(-2), 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
    }


}

public class WindowItem
{
    public string Title { get; set; }
    public IntPtr Handle { get; set; }

    public WindowItem(string title, IntPtr handle)
    {
        Title = title;
        Handle = handle;
    }
}


/***
Partial Json format
{
Value[
    {
      "testPlan": {
        "id": 820751,
        "name": "V15.0_HYSYS"
      },
      "testSuite": {
        "id": 842434,
        "name": "New Features_PI17"
      },
      "isAutomated": false,
      "results": {
        "lastResultDetails": {
          "duration": 0,
          "dateCompleted": "2023-03-17T01:03:43.7Z",
          "runBy": {
            "displayName": "Li, Polly (Qinghua)",
            "id": "351ecece-64f5-6823-9d40-41cf47722595"
          }
        },
        "lastResultId": 100000,
        "lastRunBuildNumber": "0",
        "state": "notReady",
        "lastResultState": "completed",
        "outcome": "failed",
        "lastTestRunId": 1531412
      },
      "testCaseReference": {
        "id": 825733,
        "name": "V15 AOM: Change to make SQLite as the default DB engine(Hysys AOM)",
        "state": "Design"
      }
    }
  ],  
  "count": 1
}
***/

public class VSTSDataProvider{
    private static string vstsBaseUrl = @"https://aspentech-alm.visualstudio.com/AspenTech/_apis/testplan/";
    public static TestPlan testPlan; 
    public static TestSutie testSutie= testPlan.ChildTestSutie;
    public static TestCase testCase= testSutie.ChildTestCase;

    static readonly HttpClient httpClient=new HttpClient();

//continuationToken=-2147483648;25, 这里的25指的是获取的最大ItemsJson数量.
//          改成-1(-2147483648;-1)或者不填写(-2147483648;)就可以获取全部
//returnIdentityRef  是否附上内容引用
//includePointDetails 是否包含内容额外详细信息
//isRecursive 是否递归

    public VSTSDataProvider(int testPlanID,int testSuiteID,string cookie,int itemsNum=-1,bool returnIdentityRef=false,bool includePointDetails=true,bool isRecursive=false){
        string path = $@"Plans/{testPlanID}/Suites/{testSuiteID}/TestPoint";
        string query = $@"?continuationToken=-2147483648;{itemsNum}&returnIdentityRef={returnIdentityRef}&includePointDetails={includePointDetails}&isRecursive={isRecursive}";
        string targetUrl=vstsBaseUrl+path+query;
        if (!Uri.TryCreate(targetUrl,UriKind.Absolute,out Uri dataUri))
        {   
            throw new HttpRequestException("Uri Wrong. Please check uri.");
        }
        GetDataFromVSTS(dataUri,cookie);
    
    }

    private async Task GetDataFromVSTS(Uri targetUrl,string cookie){
        httpClient.DefaultRequestHeaders.Add("Cookie",cookie);
        var responseMessage=await httpClient.GetAsync(targetUrl);
        string responseBody=await responseMessage.Content.ReadAsStringAsync();
        dynamic responseData=JsonConvert.DeserializeObject(responseBody);

        int a=0;
    }

}

public enum OutcomeState{
    Failed,//failed
    Active,//Unspecified
    Passed,//passed
}
public class TestCase
{

    public string Name { get; set; }
    public int ID { get; set; }
    public OutcomeState Outcome { get; set; }
    public bool IsAutomated { get; set; }
    public TestSutie ParentTestSutie { get; set; }

    public string OutcomeStr
    {
        get
        {
            switch (Outcome)
            {
                case OutcomeState.Failed:
                    return "failed";
                case OutcomeState.Active:
                    return "unspecified"; // Active对应的字符串为"unspecified"
                case OutcomeState.Passed:
                    return "passed";
                default:
                    throw new InvalidOperationException($"Unexpected Outcome value: {Outcome}");
            }
        }
        set
        {
            switch (value.ToLower())
            {
                case "failed":
                    Outcome = OutcomeState.Failed;
                    break;
                case "unspecified": // Active对应的字符串为"unspecified"
                    Outcome = OutcomeState.Active;
                    break;
                case "passed":
                    Outcome = OutcomeState.Passed;
                    break;
                default:
                    throw new ArgumentException($"Invalid Outcome value: {value}", nameof(OutcomeStr));
            }
        }
    }

    // public string OutcomeStr
    // {
    //     get { return Outcome.ToString().ToLower(); }
    //     set
    //     {
    //         if (Enum.TryParse(value, true, out OutcomeState outcomeState))
    //         {
    //             Outcome = outcomeState;
    //         }else if(value.Equals("unspecified",StringComparison.OrdinalIgnoreCase)){
    //             Outcome = OutcomeState.Active;
    //         }
    //         else
    //         {
    //             throw new ArgumentException("Invalid outcome state.", nameof(OutcomeStr));
    //         }
    //     }
    // }

}
public class TestSutie{
    public string Name {get;set;}
    public int ID {get;set;}
    public TestCase ChildTestCase{get;set;}
    public TestPlan ParentTestPlan{get;set;}

}
public class TestPlan{
    public string Name {get;set;}
    public int ID {get;set;}
    public TestSutie ChildTestSutie{get;set;}

}