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
        public delegate void FileBrowserCallback(string fileFo);

        private FileBrowser() { }

        //This method recieves a delegate to callback when the file is already selected
        public void getFilePathWithFormat(string fileFormat, FileBrowserCallback callback)
        {
            lazyInitComponents();
            openFileDialog.Filter = fileFormat;
            DialogResult dialogResult = openFileDialog.ShowDialog();
            //Invoke the delegate
            switch (dialogResult) {

                case DialogResult.OK:
                    string path = openFileDialog.FileName;
                    Debug.WriteLine(path);
                    callback.Invoke(path);
                    break;

                case DialogResult.No:
                    path =  "";
                    callback.Invoke(path);
                    break;
                case DialogResult.Cancel:
                    path = "";
                    callback.Invoke(path);
                    break;
            }


        }

        private void lazyInitComponents() {
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
