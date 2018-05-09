using System.Collections.Generic;
using System.Text;

namespace Berry.WebControl.Tree
{
    /// <summary>
    /// 构造树形Json
    /// </summary>
    public static class TreeJson
    {
        /// <summary>
        /// 转换树Json
        /// </summary>
        /// <param name="list">数据源</param>
        /// <param name="parentId">父节点</param>
        /// <returns></returns>
        public static string TreeToJson(this List<TreeEntity> list, string parentId = "0")
        {
            StringBuilder strJson = new StringBuilder();
            List<TreeEntity> item = list.FindAll(t => t.ParentId == parentId);

            strJson.Append("[");
            if (item.Count > 0)
            {
                foreach (TreeEntity entity in item)
                {
                    strJson.Append("{");

                    strJson.Append("\"id\":\"" + entity.Id + "\",");

                    if (!string.IsNullOrEmpty(entity.Text))
                    {
                        strJson.Append("\"text\":\"" + entity.Text.Replace("&nbsp;", "") + "\",");
                    }

                    strJson.Append("\"value\":\"" + entity.Value + "\",");

                    if (!string.IsNullOrEmpty(entity.Attribute))
                    {
                        strJson.Append("\"" + entity.Attribute + "\":\"" + entity.AttributeValue + "\",");
                    }

                    if (!string.IsNullOrEmpty(entity.AttributeA))
                    {
                        strJson.Append("\"" + entity.AttributeA + "\":\"" + entity.AttributeValueA + "\",");
                    }

                    if (!string.IsNullOrEmpty(entity.Title.Replace("&nbsp;", "")))
                    {
                        strJson.Append("\"title\":\"" + entity.Title.Replace("&nbsp;", "") + "\",");
                    }

                    if (!string.IsNullOrEmpty(entity.ImageUrl.Replace("&nbsp;", "")))
                    {
                        strJson.Append("\"img\":\"" + entity.ImageUrl.Replace("&nbsp;", "") + "\",");
                    }

                    if (entity.Checkstate != null)
                    {
                        strJson.Append("\"checkstate\":" + entity.Checkstate + ",");
                    }

                    if (!string.IsNullOrEmpty(entity.ParentId))
                    {
                        strJson.Append("\"parentnodes\":\"" + entity.ParentId + "\",");
                    }

                    if (entity.Level != null)
                    {
                        strJson.Append("\"Level\":" + entity.Level + ",");
                    }

                    strJson.Append("\"showcheck\":" + entity.Showcheck.ToString().ToLower() + ",");

                    strJson.Append("\"isexpand\":" + entity.Isexpand.ToString().ToLower() + ",");

                    if (entity.Complete)
                    {
                        strJson.Append("\"complete\":" + entity.Complete + ",");
                    }

                    strJson.Append("\"hasChildren\":" + entity.HasChildren + ",");

                    strJson.Append("\"ChildNodes\":" + TreeToJson(list, entity.Id) + "");

                    strJson.Append("},");
                }
                strJson = strJson.Remove(strJson.Length - 1, 1);
            }
            strJson.Append("]");

            return strJson.ToString();
        }
    }
}