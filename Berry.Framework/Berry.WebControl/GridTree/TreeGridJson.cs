using System.Collections.Generic;
using System.Text;

namespace Berry.WebControl.GridTree
{
    /// <summary>
    /// 构造树形表格Json
    /// </summary>
    public static class TreeGridJson
    {
        public static int lft = 1, rgt = 1000000;

        /// <summary>
        /// 转换树形Json
        /// </summary>
        /// <param name="listData">数据源</param>
        /// <param name="index"></param>
        /// <param name="parentId">父节点</param>
        /// <returns></returns>
        public static string TreeJson(List<TreeGridEntity> listData, int index, string parentId)
        {
            StringBuilder sb = new StringBuilder();
            var childNodeList = listData.FindAll(t => t.ParentId == parentId);
            if (childNodeList.Count > 0) { index++; }

            foreach (TreeGridEntity entity in childNodeList)
            {
                string strJson = entity.EntityJson;
                strJson = strJson.Insert(1, "\"level\":" + index + ",");
                strJson = strJson.Insert(1, "\"isLeaf\":" + (entity.HasChildren != true).ToString().ToLower() + ",");
                strJson = strJson.Insert(1, "\"expanded\":" + (entity.Expanded).ToString().ToLower() + ",");
                strJson = strJson.Insert(1, "\"lft\":" + lft++ + ",");
                strJson = strJson.Insert(1, "\"rgt\":" + rgt-- + ",");
                sb.Append(strJson);
                sb.Append(TreeJson(listData, index, entity.Id));
            }
            return sb.ToString().Replace("}{", "},{");
        }

        /// <summary>
        /// 转换树形Json
        /// </summary>
        /// <param name="list">数据源</param>
        /// <returns></returns>
        public static string TreeJson(this List<TreeGridEntity> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ \"rows\": [");
            sb.Append(TreeJson(list, -1, "0"));
            sb.Append("]}");
            return sb.ToString();
        }
    }
}