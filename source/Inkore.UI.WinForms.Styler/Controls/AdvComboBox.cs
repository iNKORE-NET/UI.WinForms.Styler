/************************************************************************************
 *源码来自(16aspx源码)  www.16aspx.com
 *如果对该源码有问题可以直接点击下方的提问按钮进行提问哦
 *站长将亲自帮你解决问题
 *16aspx源码-找到你需要的C#源码，交流和学习
************************************************************************************/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Inkore.UI.WinForms.Styler.Controls
{
    [ToolboxBitmap(typeof(ComboBox))]
    public class AdvComboBox : System.Windows.Forms.ComboBox
    {
        private string cueBannerText_ = string.Empty;
        [Description("Gets or sets the cue text that is displayed on a ComboBox control."), Category("Appearance"), DefaultValue("")]
        public string CueBannerText
        {
            get
            {
                return cueBannerText_;
            }
            set
            {
                cueBannerText_ = value;
                this.SetCueText();
            }
        }

        private void SetCueText()
        {
            NativeMethods.SendMessage(this.Handle, NativeMethods.CB_SETCUEBANNER, IntPtr.Zero, cueBannerText_);
        }

        public AdvComboBox()
        {
            this.FlatStyle = FlatStyle.System;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
