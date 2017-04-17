using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using ScheduleManager.enums;

namespace ScheduleManager.common
{
    public sealed class FileBrowser
    {

        private OpenFileDialog openFileDialog = null;
        private static FileBrowser instance = null;
        private static readonly object padlock = new object();

        private FileBrowser() { }

        public string getFilePathWithFormat(String fileFormat)
        {
            lazyInitComponents();
            openFileDialog.Filter = fileFormat;
            DialogResult dialogResult = openFileDialog.ShowDialog();
            switch (dialogResult) {

                case DialogResult.OK:
                    string path = openFileDialog.FileName;
                    Debug.WriteLine(path);
                    break;

                case DialogResult.No: return "";

                case DialogResult.Cancel: return "";

            }

            return null;
        }

        public void lazyInitComponents() {
            if (openFileDialog == null) {
                openFileDialog = new OpenFileDialog();
            }
        }

        public static FileBrowser Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FileBrowser();
                    }
                    return instance;
                }

            }
        }



    }
}
