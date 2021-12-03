﻿using System;
using System.Windows;
#if NET40
using Microsoft.Windows.Shell;
#else
using System.Windows.Shell;
#endif

namespace Panuon.UI.Silver.Utils
{
    static class WindowChromeUtil
    {
        internal static void SetIsHitTestVisibleInChrome(UIElement element, bool hitTestVisible)
        {
            WindowChrome.SetIsHitTestVisibleInChrome(element, hitTestVisible);
        }

        internal static void SetCaptionHeight(WindowX windowX, double height)
        {
            windowX.Dispatcher.BeginInvoke(new Action(() =>
            {
                var chrome = WindowChrome.GetWindowChrome(windowX);
                if (chrome == null || double.IsNaN(height) || double.IsInfinity(height))
                {
                    return;
                }
                chrome.CaptionHeight = height;
            }), System.Windows.Threading.DispatcherPriority.Loaded);
        }

    }
}