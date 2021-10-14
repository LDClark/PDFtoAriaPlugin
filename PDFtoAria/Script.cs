using PDFtoAria;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS
{
    class Script
    {
        public Script()
        {
        }

        public void Execute(ScriptContext context)
        {
            Patient patient = context.Patient;
            if (patient == null)
                throw new ApplicationException("Please open a patient before using this script.");

            ExternalPlanSetup plan = context.ExternalPlanSetup;
            if (plan == null)
                throw new ApplicationException("Please select a plan before using this script.");

            String locPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            String setFilePath = Path.Combine(locPath, @"PDFtoAria.setting");
            List<DocSettings> docSettingsLs = new List<DocSettings>();
            DocSettings docSettings = new DocSettings();
            if (File.Exists(setFilePath))
            {
                try
                {
                    using (StreamReader readr = new StreamReader(setFilePath))
                    {
                        String currLine;
                        while ((currLine = readr.ReadLine()) != null)
                        {
                            DocSettings docSet = new DocSettings();
                            bool succ = docSet.ReadSettings(currLine);
                            if (succ) { docSettingsLs.Add(docSet); }
                            else
                            {
                                throw new ApplicationException("Something wrong in PDFtoAria.setting, please check the file before using this script");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new ApplicationException("Error in reading PDFtoAria.setting, please check the file before using this script");
                }
            }
            else
            {
                throw new ApplicationException("Cannot locate PDFtoAria.setting, please check the file before using this script");
            }

            var viewModel = new MainViewModel(context.CurrentUser, patient, plan, docSettingsLs[0]);
            var mainWindow = new MainWindow();
            mainWindow.DataContext = viewModel;
            mainWindow.Title = "PDFtoAria";
            mainWindow.ShowDialog();
        }
    }
}

