using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxZKFPEngXControl;
using Finger.Entity;

namespace Finger.UI
{    
    public static class Robot
    {
        public static AxZKFPEngX Control = null;
        public static int FpcHandle;
        public static int ImageWidth;
        public static int ImageHeight;
        public static int SensorCount;
        public static int SensorIndex;
        public static string SensorSN;
        public static int MatchType;
        public static bool IsConnected;
        public static RobotStatus Status;      
        
        public static int InitControl()
        {
            if(Control == null)
            {
                return 1;
            }

            Control.FPEngineVersion = "9";
            Control.SensorIndex = 0;

            try
            {
                Control.EndEngine();
            }
            catch { }
            
            int initResult = Control.InitEngine();

            if (initResult == 0)
            {
                FpcHandle = Control.CreateFPCacheDB();

                SensorCount = Control.SensorCount;
                SensorIndex = Control.SensorIndex;
                ImageWidth = Control.ImageWidth;
                ImageHeight = Control.ImageHeight;
                SensorSN = Control.SensorSN;

                MatchType = 2;
                IsConnected = true;
            }

            return initResult;
        }

        public static void AddRegTemplateToFPCache(List<Visitor> list)
        {
            if (!IsConnected) return;            

            foreach (Visitor v in list)
            {
                if(v.Template.Length > 0)
                {
                    Control.AddRegTemplateStrToFPCacheDB(FpcHandle, v.FPID, v.Template);
                }                
            }                      
        }

        public static void AddSingleTemplateToFPCache(int FPID, string template)
        {
            Control.AddRegTemplateStrToFPCacheDB(FpcHandle, FPID, template);
        }

        public static void BeginCapture()
        {
            if (!IsConnected) return;

            if (Control.IsRegister)
            {
                Control.CancelEnroll();
            }

            SetAutoIdentify(true);
            Control.BeginCapture();
            
            Status = RobotStatus.capture;
        }

        public static void CancelCapture()
        {
            if (!IsConnected) return;

            if (Status == RobotStatus.capture)
            {
                Control.CancelCapture();
                Status = RobotStatus.init;
            }
        }

        public static void BeginEnroll()
        {
            if (IsConnected)
            {
                if (Control.IsRegister)
                {
                    Control.CancelEnroll();
                }
                Control.EnrollCount = 3;
                Control.BeginEnroll();
                Status = RobotStatus.enroll;
            }            
        }

        public static void CancelEnroll()
        {
            Control.CancelEnroll();
            Status = RobotStatus.init;
        }

        public static string GetLatestTemplate()
        {
            return Control.GetTemplateAsString();
        }

        /// <summary>
        /// 设置捕捉到指纹后是否自动匹配
        /// </summary>
        public static void SetAutoIdentify(bool auto)
        {
            if (!IsConnected) return;

            Control.SetAutoIdentifyPara(auto, FpcHandle, 9);
        }

        public static int MatchTemplateInFPCache(string templateStr)
        {
            int score = 0, processedFPNumber = 0;

            return Control.IdentificationFromStrInFPCacheDB(FpcHandle, templateStr, ref score, ref processedFPNumber);
        }

        public static void Close()
        {
            if(Control != null)
            {
                if (Control.IsRegister)
                {
                    Control.CancelEnroll();
                }else
                {
                    Control.CancelCapture();
                }

                Control.EndEngine();

                IsConnected = false;
            }
        }
    }
}
