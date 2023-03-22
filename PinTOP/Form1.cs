using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;


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