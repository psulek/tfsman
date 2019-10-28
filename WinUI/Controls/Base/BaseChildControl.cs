#region Copyright Tom Horn Enterprise © 2009

/*
 * Created by: Peter Šulek
 *    Created: 2009. 02. 25
 */

#endregion

using System.Windows.Forms;

using TFSManager.Core;
using TFSManager.Core.WinForms;

namespace TFSManager.Controls
{
    /// <summary>
    /// BaseChildControl
    /// </summary>
    public class BaseChildControl: UserControl, IChildControl
    {
        #region IChildControl Members

        public IMasterForm OwnerForm { get; private set; }

        public virtual void InitializeControl(IMasterForm ownerForm)
        {
            this.OwnerForm = ownerForm;
        }

        #endregion
    }
}