using Berry.Entity.CustomManage;
using Berry.IService.CustomManage;
using Berry.Data.Repository;
using Berry.Entity.CommonEntity;
using System.Collections.Generic;
using System.Linq;
using Berry.Code.Operator;
using Berry.Extension;
using Newtonsoft.Json.Linq;

namespace Berry.Service.CustomManage
{
    /// <summary>
    /// �� ����V1.0.0
    /// Copyright (c) 2017-2018
    /// �� ������ʦ��
    /// �� �ڣ�2018-08-13 22:13
    /// �� �����û�����
    /// </summary>
    public class UserDemandService : RepositoryFactory, IUserDemandService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<UserDemandEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            var expression = LambdaExtension.True<UserDemandEntity>();
            JObject queryParam = queryJson.TryToJObject();
            if (queryParam != null)
            {
                if (!queryParam["Title"].IsEmpty())
                {
                    string Title = queryParam["Title"].ToString();
                    expression = expression.And(t => t.Title.Contains(Title));
                }
                if (!queryParam["CategoryId"].IsEmpty())
                {
                    string CategoryId = queryParam["CategoryId"].ToString();
                    expression = expression.And(t => t.CategoryId == CategoryId);
                }
            }

            if (OperatorProvider.Provider.Current().IsSystem)
            {
                expression = expression.And(t => t.IsDelete == false);
            }
            else
            {
                expression = expression.And(t => t.IsDelete == false && t.CreateUserId == OperatorProvider.Provider.Current().UserId);
            }
            return this.BaseRepository().FindList<UserDemandEntity>(expression, pagination);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<UserDemandEntity> GetList(string queryJson)
        {
            var expression = LambdaExtension.True<UserDemandEntity>();
            JObject queryParam = queryJson.TryToJObject();
            if (queryParam != null)
            {
                if (!queryParam["Title"].IsEmpty())
                {
                    string Title = queryParam["Title"].ToString();
                    expression = expression.And(t => t.Title.Contains(Title));
                }
                if (!queryParam["CategoryId"].IsEmpty())
                {
                    string CategoryId = queryParam["CategoryId"].ToString();
                    expression = expression.And(t => t.CategoryId == CategoryId);
                }
            }

            if (OperatorProvider.Provider.Current().IsSystem)
            {
                expression = expression.And(t => t.IsDelete == false);
            }
            else
            {
                expression = expression.And(t => t.IsDelete == false && t.CreateUserId == OperatorProvider.Provider.Current().UserId);
            }
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public UserDemandEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<UserDemandEntity>(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete<UserDemandEntity>(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, UserDemandEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update<UserDemandEntity>(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert<UserDemandEntity>(entity);
            }
        }
        #endregion
    }
}
