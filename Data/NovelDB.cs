using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Model.DBEntity;

namespace Novel.Data
{
    public class NovelDB : AccessDbBase
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["AccessDB"].ConnectionString;
        private static DbConnection _dbConnection = new OleDbConnection(ConnectionString);
        
        public int AddNovel(NovelDBEntity novel)
        {
            OleDbParameter[] parameters = new OleDbParameter[5];

            parameters[0] = new OleDbParameter("@NovelName", OleDbType.VarWChar, 200);
            parameters[1] = new OleDbParameter("@NovelAuthor", OleDbType.VarWChar, 200);
            parameters[2] = new OleDbParameter("@CharacterCount", OleDbType.Integer, 4);
            parameters[3] = new OleDbParameter("@IsFinished", OleDbType.Boolean, 1);
            parameters[4] = new OleDbParameter("@NovelDesc", OleDbType.VarWChar);

            parameters[0].Value = novel.NovelName;
            parameters[1].Value = novel.NovelAuthor;
            parameters[2].Value = novel.CharacterCount;
            parameters[3].Value = novel.IsFinished;
            parameters[4].Value = novel.NovelDesc ?? "";

            string str_sql = "insert into Novel (NovelName,NovelAuthor,CharacterCount,IsFinished,NovelDesc) values (@NovelName,@NovelAuthor,@CharacterCount,@IsFinished,@NovelDesc)";

            return DbHelper.ExecuteInsertScalar(_dbConnection,CommandType.Text, str_sql, parameters);

        }

        public int AddChapter(ChapterDBEntity chapter)
        {
            OleDbParameter[] parameters = new OleDbParameter[4];

            parameters[0] = new OleDbParameter("@NovelId", OleDbType.Integer, 4);
            parameters[1] = new OleDbParameter("@ChapterName", OleDbType.VarWChar, 200);
            parameters[2] = new OleDbParameter("@ChapterUrl", OleDbType.VarWChar, 200);
            parameters[3] = new OleDbParameter("@NovelOrder", OleDbType.Integer, 4);

            parameters[0].Value = chapter.NovelId;
            parameters[1].Value = chapter.ChapterName;
            parameters[2].Value = chapter.ChapterUrl;
            parameters[3].Value = chapter.ChapterOrder;

            string str_sql = "insert into Chapter (NovelId,ChapterName,ChapterUrl,ChapterOrder) values (@NovelId,@ChapterName,@ChapterUrl,@ChapterOrder)";

            return DbHelper.ExecuteInsertScalar(_dbConnection,CommandType.Text, str_sql, parameters);
            
        }

        public void AddChapterContent(ChapterContentDBEntity chapterContent)
        {
            OleDbParameter[] parameters = new OleDbParameter[2];

            parameters[0] = new OleDbParameter("@ChapterId", OleDbType.Integer, 4);
            parameters[1] = new OleDbParameter("@ChapterContent", OleDbType.VarWChar);

            parameters[0].Value = chapterContent.ChapterId;
            parameters[1].Value = chapterContent.ChapterContent;

            string str_sql = "insert into ChapterContent (ChapterId,ChapterContent) values (@ChapterId,@ChapterContent)";

            DbHelper.ExecuteNonQuery(_dbConnection, CommandType.Text, str_sql, parameters);
        }

        public ChapterDBEntity GetChapterById(int chapterId)
        {
            OleDbParameter[] parameter = new OleDbParameter[]
            {
                new OleDbParameter("@ChapterId", OleDbType.Integer, 4)
            };

            parameter[0].Value = chapterId;
            string str_sql = "select * from Chapter where ChapterId=@ChapterId";

            ChapterDBEntity info = new ChapterDBEntity();
            var dr = DbHelper.ExecuteReader(CommandType.Text, str_sql, parameter);
            if (dr.Read())
            {
                info.ChapterId = int.Parse(dr["ChapterId"].ToString());
                info.NovelId = int.Parse(dr["NovelId"].ToString());
                info.ChapterName = dr["ChapterName"].ToString();
                info.ChapterUrl = dr["ChapterUrl"].ToString();
                info.ChapterOrder = int.Parse(dr["ChapterOrder"].ToString());
            }
            dr.Close();

            return info;
        }
    }
}
