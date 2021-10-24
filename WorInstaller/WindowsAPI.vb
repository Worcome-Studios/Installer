Imports System.Runtime.InteropServices
Module WindowsComponents
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Dim DoubleBytes As Double
    Public Function FormatBytes(ByVal BytesCaller As ULong, ByVal GetSizeString As Boolean) As String
        Try
            Select Case BytesCaller
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(BytesCaller / 1099511627776) 'TB
                    If GetSizeString = True Then
                        Return FormatNumber(DoubleBytes, 2) & " TB"
                    Else
                        Return FormatNumber(DoubleBytes, 2)
                    End If
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(BytesCaller / 1073741824) 'GB
                    If GetSizeString = True Then
                        Return FormatNumber(DoubleBytes, 2) & " GB"
                    Else
                        Return FormatNumber(DoubleBytes, 2)
                    End If
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(BytesCaller / 1048576) 'MB
                    If GetSizeString = True Then
                        Return FormatNumber(DoubleBytes, 2) & " MB"
                    Else
                        Return FormatNumber(DoubleBytes, 2)
                    End If
                Case 1024 To 1048575
                    DoubleBytes = CDbl(BytesCaller / 1024) 'KB
                    If GetSizeString = True Then
                        Return FormatNumber(DoubleBytes, 2) & " KB"
                    Else
                        'remover tres "0"
                        Return FormatNumber(DoubleBytes, 2)
                    End If
                Case 0 To 1023
                    DoubleBytes = BytesCaller ' bytes
                    If GetSizeString = True Then
                        Return FormatNumber(DoubleBytes, 2) & " bytes"
                    Else
                        Return FormatNumber(DoubleBytes, 2)
                    End If
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function
End Module
Public Class TaskbarProgress
    Public Enum TaskbarStates
        Fail = 3
        NoProgress = 0
        Indeterminate = 1
        Normal = 2
        Paused = 8
    End Enum
    <ComImport(),
     Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface ITaskbarList3
        ' ITaskbarList
        <PreserveSig()>
        Sub HrInit()
        <PreserveSig()>
        Sub AddTab(ByVal hwnd As IntPtr)
        <PreserveSig()>
        Sub DeleteTab(ByVal hwnd As IntPtr)
        <PreserveSig()>
        Sub ActivateTab(ByVal hwnd As IntPtr)
        <PreserveSig()>
        Sub SetActiveAlt(ByVal hwnd As IntPtr)
        ' ITaskbarList2
        <PreserveSig()>
        Sub MarkFullscreenWindow(ByVal hwnd As IntPtr, ByVal fFullscreen As Boolean)
        ' ITaskbarList3
        <PreserveSig()>
        Sub SetProgressValue(ByVal hwnd As IntPtr, ByVal ullCompleted As UInt64, ByVal ullTotal As UInt64)
        <PreserveSig()>
        Sub SetProgressState(ByVal hwnd As IntPtr, ByVal state As TaskbarStates)
    End Interface
    <ComImport(),
     Guid("56fdf344-fd6d-11d0-958a-006097c9a090"),
     ClassInterface(ClassInterfaceType.None)>
    Private Class TaskbarInstances
    End Class
    Private Shared taskbarInstance As ITaskbarList3 = CType(New TaskbarInstances, ITaskbarList3)
    Private Shared taskbarSupported As Boolean = (Environment.OSVersion.Version >= New Version(6, 1))
    Public Shared Sub SetState(ByVal windowHandle As IntPtr, ByVal taskbarState As TaskbarStates)
        If taskbarSupported Then
            taskbarInstance.SetProgressState(windowHandle, taskbarState)
        End If
    End Sub
    Public Shared Sub SetValue(ByVal windowHandle As IntPtr, ByVal progressValue As Double, ByVal progressMax As Double)
        If taskbarSupported Then
            taskbarInstance.SetProgressValue(windowHandle, CType(progressValue, System.UInt64), CType(progressMax, System.UInt64))
        End If
    End Sub
End Class
Public Class WindowsApi
    Private Declare Function FlashWindowEx Lib "User32" (ByRef fwInfo As FLASHWINFO) As Boolean
    Public Enum FlashWindowFlags As UInt32
        FLASHW_STOP = 0
        FLASHW_CAPTION = 1
        FLASHW_TRAY = 2
        FLASHW_ALL = 3
        FLASHW_TIMER = 4
        FLASHW_TIMERNOFG = 12
    End Enum

    Public Structure FLASHWINFO
        Public cbSize As UInt32
        Public hwnd As IntPtr
        Public dwFlags As FlashWindowFlags
        Public uCount As UInt32
        Public dwTimeout As UInt32
    End Structure

    Public Shared Function FlashWindow(ByRef handle As IntPtr, ByVal FlashTitleBar As Boolean, ByVal FlashTray As Boolean, ByVal FlashCount As Integer) As Boolean
        If handle = Nothing Then Return False
        Try
            Dim fwi As New FLASHWINFO
            With fwi
                .hwnd = handle
                If FlashTitleBar Then .dwFlags = .dwFlags Or FlashWindowFlags.FLASHW_CAPTION
                If FlashTray Then .dwFlags = .dwFlags Or FlashWindowFlags.FLASHW_TRAY
                .uCount = CUInt(FlashCount)
                If FlashCount = 0 Then .dwFlags = .dwFlags Or FlashWindowFlags.FLASHW_TIMERNOFG
                .dwTimeout = 0
                .cbSize = CUInt(System.Runtime.InteropServices.Marshal.SizeOf(fwi))
            End With
            Return FlashWindowEx(fwi)
        Catch
            Return False
        End Try
    End Function
End Class