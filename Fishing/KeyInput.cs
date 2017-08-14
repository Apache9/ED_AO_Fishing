using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace Fishing
{
    class KeyInput
    {
        [DllImport("user32.dll")]
        static extern UInt32 SendInput(UInt32 nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(0)]
            public Int32 type;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public Int32 dx;
            public Int32 dy;
            public Int32 mouseData;
            public Int32 dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public Int16 wVk;
            public Int16 wScan;
            public Int32 dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public Int32 uMsg;
            public Int16 wParamL;
            public Int16 wParamH;
        }

        private const int INPUT_KEYBOARD = 1;
        private const int KEYEVENTF_KEYUP = 0x0002;
        private const int KEYEVENTF_SCANCODE = 0x0008;

        private INPUT createKeyDown(Microsoft.DirectX.DirectInput.Key key)
        {
            INPUT keyDown = new INPUT();
            keyDown.type = INPUT_KEYBOARD;
            keyDown.ki.wScan = (Int16)key;
            keyDown.ki.dwFlags = KEYEVENTF_SCANCODE;
            return keyDown;
        }

        private INPUT createKeyUp(Microsoft.DirectX.DirectInput.Key key)
        {
            INPUT keyUp = new INPUT();
            keyUp.type = INPUT_KEYBOARD;
            keyUp.ki.wScan = (Int16)key;
            keyUp.ki.dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP;
            return keyUp;
        }

        public void pressKey(Microsoft.DirectX.DirectInput.Key key)
        {
            INPUT[] keyDown = new INPUT[1] { createKeyDown(key) };
            INPUT[] keyUp = new INPUT[1] { createKeyUp(key) };
            SendInput(1, keyDown, Marshal.SizeOf(keyDown[0]));
            Thread.Sleep(50);
            SendInput(1, keyUp, Marshal.SizeOf(keyUp[0]));
        }
    }
}
