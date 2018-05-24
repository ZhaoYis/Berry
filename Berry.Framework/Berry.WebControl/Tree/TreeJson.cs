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
            List<TreeEntity> item = list.FindAll(t => t.parentId == parentId);

            strJson.Append("[");
            if (item.Count > 0)
            {
                foreach (TreeEntity entity in item)
                {
                    strJson.Append("{");

                    strJson.Append("\"id\":\"" + entity.id + "\",");

                    if (!string.IsNullOrEmpty(entity.text))
                    {
                        strJson.Append("\"text\":\"" + entity.text.Replace("&nbsp;", "") + "\",");
                    }

                    strJson.Append("\"value\":\"" + entity.value + "\",");

                    if (!string.IsNullOrEmpty(entity.Attribute))
                    {
                        strJson.Append("\"" + entity.Attribute + "\":\"" + entity.AttributeValue + "\",");
                    }

                    if (!string.IsNullOrEmpty(entity.AttributeA))
                    {
                        strJson.Append("\"" + entity.AttributeA + "\":\"" + entity.AttributeValueA + "\",");
                    }

                    if (!string.IsNullOrEmpty(entity.title))
                    {
                        strJson.Append("\"title\":\"" + entity.title.Replace("&nbsp;", "") + "\",");
                    }

                    if (!string.IsNullOrEmpty(entity.img))
                    {
                        strJson.Append("\"img\":\"" + entity.img.Replace("&nbsp;", "") + "\",");
                    }

                    if (entity.checkstate != null)
                    {
                        strJson.Append("\"checkstate\":" + entity.checkstate + ",");
                    }

                    if (!string.IsNullOrEmpty(entity.parentId))
                    {
                        strJson.Append("\"parentnodes\":\"" + entity.parentId + "\",");
                    }

                    if (entity.Level != null)
                    {
                        strJson.Append("\"Level\":" + entity.Level + ",");
                    }

                    strJson.Append("\"showcheck\":" + entity.showcheck.ToString().ToLower() + ",");

                    strJson.Append("\"isexpand\":" + entity.isexpand.ToString().ToLower() + ",");

                    if (entity.complete)
                    {
                        strJson.Append("\"complete\":" + entity.complete.ToString().ToLower() + ",");
                    }

                    strJson.Append("\"hasChildren\":" + entity.hasChildren.ToString().ToLower() + ",");

                    string childNodes = TreeToJson(list, entity.id);
                    strJson.Append("\"ChildNodes\":" + childNodes + "");

                    strJson.Append("},");
                }
                strJson = strJson.Remove(strJson.Length - 1, 1);
            }
            strJson.Append("]");

            return strJson.ToString();
        }
    }
}