using SIMS.Entity;
using SIMS.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Utils.Http
{
    public class ScoreHttpUtil:HttpUtil
    {
        /// <summary>
        /// 通过id查询成绩信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ScoreEntity GetScore(int id)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["id"] = id;
            var str = Get(UrlConfig.SCORE_GETSCORE, data);
            var socre = StrToObject<ScoreEntity>(str);
            return socre;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="courseName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedRequest<ScoreEntity> GetScores(string? studentName, string? courseName, int pageNum, int pageSize)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["courseName"] = courseName;
            data["studentName"] = studentName;
            data["pageNum"] = pageNum;
            data["pageSize"] = pageSize;
            var str = Get(UrlConfig.SCORE_GETSCORES, data);
            var socres = StrToObject<PagedRequest<ScoreEntity>>(str);
            return socres;
        }

        public static bool AddScore(ScoreEntity socre)
        {
            var ret = Post<ScoreEntity>(UrlConfig.SCORE_ADDSCORE, socre);
            return int.Parse(ret) == 0;
        }

        public static bool UpdateScore(ScoreEntity socre)
        {
            var ret = Put<ScoreEntity>(UrlConfig.SCORE_UPDATESCORE, socre);
            return int.Parse(ret) == 0;
        }

        public static bool DeleteScore(int Id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["Id"] = Id.ToString();
            var ret = Delete(UrlConfig.SCORE_DELETESCORE, data);
            return int.Parse(ret) == 0;
        }
    }
}
