using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using Microsoft.TeamFoundation.Build.Client;
using TFSManager.Core.WinForms;
using TFSManager.Core.WinForms.Controls;

namespace TFSManager.Core
{
    public static class Extensions
    {
 
        public static int InRange(this int x, int lo, int hi)
        {
            Debug.Assert(lo <= hi);
            return x < lo ? lo : (x > hi ? hi : x);
        }
        public static bool IsInRange(this int x, int lo, int hi)
        {
            return x >= lo && x <= hi;
        }
        public static Color HalfMix(this Color one, Color two)
        {
            return Color.FromArgb(
                (one.A + two.A) >> 1,
                (one.R + two.R) >> 1,
                (one.G + two.G) >> 1,
                (one.B + two.B) >> 1);
        }

        public static void SafeInvokeAction(this Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public static void SafeInvokeAction(this AsyncWorkAction action, AsyncWorkControl workControl)
        {
            if (action != null)
            {
                action(workControl);
            }
        }

        public static void SafeInvokeAction<TEventArgs>(this AsyncWorkEventHandler<TEventArgs> action, AsyncWorkControl workControl, TEventArgs e) where TEventArgs : EventArgs
        {
            if (action != null)
            {
                action(workControl, e);
            }
        }

        public static IEnumerable<TRet> ToCollection<TRet>(this ICollection collection, Func<object, TRet> itemSelector)
        {
            List<TRet> result = new List<TRet>();

            foreach (object item in collection)
            {
                TRet genericItem = itemSelector(item);
                result.Add(genericItem);
            }

            return result;
        }

        public static string GetConfigurationFolderPath(this IBuildDefinition definition)
        {
            string processParameters = definition.ProcessParameters;
            XDocument document = XDocument.Parse(processParameters);
            var q = from dic in document.Elements()
                    where dic.Name.LocalName == "Dictionary"
                    //let childElement = dic.Elements().Single(element => element.LastAttribute.Value == "ConfigurationFolderPath")
                    let childElement = dic.Elements().Single(element => element.Attributes().Any(attr => attr.Value == "ConfigurationFolderPath"))
                    select childElement.Value;
            return q.Single();
        }

        public static BuildProcessParameters GetBuildProcessParameters(this IBuildDefinition definition)
        {
            return BuildProcessParameters.FromXml(definition.ProcessParameters);
        }
    }
}