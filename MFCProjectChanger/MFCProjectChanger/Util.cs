using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace MFCProjectChanger
{
    public static class Util
    {
        public enum RenameResult
        {
            Failed = -1,
            NotMatched = 0,
            Successed
        }


        /// <summary>
        /// 파일의 인코딩을 체크하는 메소드
        /// </summary>
        /// <param name="strPath">파일 경로</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string strPath)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(strPath, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // TODO MFC노리터.vcxproj 파일이 왜 UTF8이 아닌지 확인하기

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.GetEncoding("euc-kr");
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strPath"></param>
        /// <param name="strCurPrjName"></param>
        /// <param name="strChgPrjName"></param>
        /// <returns></returns>
        public static RenameResult FileRename(string strPath, string strCurPrjName, string strChgPrjName)
        {
            RenameResult eResult = RenameResult.Failed;

            try
            {
                if (File.Exists(strPath))
                {
                    string strNewPath = string.Empty;
                    string strFolderPath = strPath.Substring(0, strPath.LastIndexOf(@"\") + 1);
                    string strFileName = strPath.Substring(strPath.LastIndexOf(@"\") + 1);
                    if (strFileName.IndexOf(strCurPrjName) == 0)
                    {
                        strFileName = strFileName.Replace(strCurPrjName, strChgPrjName);
                        strNewPath = strFolderPath + strFileName;
                        File.Move(strPath, strNewPath);
                        eResult = RenameResult.Successed;
                    }
                    else
                        eResult = RenameResult.NotMatched;
                }
            }
            catch { }

            return eResult;
        }
    }
}
