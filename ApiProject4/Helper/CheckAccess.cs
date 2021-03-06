﻿using FoxLearn.License;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ApiProject4.Helper
{
   public static class CheckAccess
    {
        public static bool CheckLicense()
        {
            try
            {
                string LicFile = @"C:\ProgramData\Autodesk\Revit\Addins\2019\Key.lic";
                string machine = @"C:\ProgramData\Autodesk\Revit\Addins\2019\MachineID.txt";
#if RELEASE2020
                LicFile = @"C:\ProgramData\Autodesk\Revit\Addins\2020\Key.lic";
                machine = @"C:\ProgramData\Autodesk\Revit\Addins\2020\MachineID.txt";
#endif
                String ProductID = string.Empty;
                using (StreamReader sr = new StreamReader(machine))
                {
                    ProductID = sr.ReadLine();
                }

                KeyManager km = new KeyManager(ProductID);
                LicenseInfo lic = new LicenseInfo();
                int value = km.LoadSuretyFile(LicFile, ref lic);
                string productKey = lic.ProductKey;
                if (km.ValidKey(ref productKey))
                {
                    try
                    {
                        DateTime date = lic.CheckDate;
                        if (DateTime.Now <= date)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("ContactKey: ngvanphong2012@gmail.com");
                            return false;
                        }
                    }
                    catch
                    {
                        return true;
                    }

                }
                MessageBox.Show("ContactKey: ngvanphong2012@gmail.com");
                return false;
            }
            catch
            {
                MessageBox.Show("ContactKey: ngvanphong2012@gmail.com");
                return false;
            }

        }

    }
}
