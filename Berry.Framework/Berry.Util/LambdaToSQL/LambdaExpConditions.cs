using System;
using System.Linq;
using System.Linq.Expressions;

namespace LambdaToSQL
{
    internal enum LambdaExpUnion : byte
    {
        And,
        Or,
        OrderBy
    }

    /// <summary>
    /// Lambda转SQL语句
    /// </summary>
    /// <typeparam name="T">查询类</typeparam>
    public sealed class LambdaExpConditions<T>
    {
        #region 外部访问方法

        /// <summary>
        /// 获取 Where 条件语句
        /// </summary>
        /// <param name="addCinditionKey">是否加Where词</param>
        /// <returns>Where条件语句</returns>
        public string Where(bool addCinditionKey = true)
        {
            if (string.IsNullOrWhiteSpace(_aiWhereStr)) return string.Empty;

            if (addCinditionKey)
            {
                return " Where " + _aiWhereStr;
            }
            else
            {
                return _aiWhereStr;
            }
        }

        /// <summary>
        /// 获取 OrderBy 条件语句
        /// </summary>
        /// <param name="addCinditionKey">是否加Order By词</param>
        /// <returns>OrderBy 条件语句</returns>
        public string OrderBy(bool addCinditionKey = true)
        {
            if (string.IsNullOrWhiteSpace(_aiOrderByStr)) return string.Empty;

            if (addCinditionKey)
            {
                return " Order By " + _aiOrderByStr;
            }
            else
            {
                return _aiOrderByStr;
            }
        }

        #endregion 外部访问方法

        #region 混合语句增加操作

        /// <summary>
        /// 添加一个条件语句（Where/OrderBy）
        /// </summary>
        /// <param name="aiExp">条件表达示</param>
        public void Add(Expression<Func<IQueryable<T>, IQueryable<T>>> aiExp)
        {
            SetConditionStr(aiExp, LambdaExpUnion.And);
        }

        /// <summary>
        /// 当给定条件满足时,添加一个条件语句（Where/OrderBy）
        /// </summary>
        /// <param name="aiCondition">当给定条件满足时</param>
        /// <param name="aiExp">条件表达示</param>
        public void Add(bool aiCondition, Expression<Func<IQueryable<T>, IQueryable<T>>> aiExp)
        {
            if (aiCondition)
            {
                SetConditionStr(aiExp, LambdaExpUnion.And);
            }
        }

        /// <summary>
        /// 当给定lambda表达式条件满足时,添加一个条件语句（Where/OrderBy）
        /// </summary>
        /// <param name="aiCondition">给定lambda表达式条件</param>
        /// <param name="aiExp">条件表达示</param>
        public void Add(Func<bool> aiCondition, Expression<Func<IQueryable<T>, IQueryable<T>>> aiExp)
        {
            Add(aiCondition(), aiExp);
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where/OrderBy），否则添加后一个
        /// </summary>
        /// <param name="aiCondition">条件</param>
        /// <param name="aiExpWhenTrue">条件为真时</param>
        /// <param name="aiExpWhenFalse">条件为假时</param>
        public void Add(bool aiCondition, Expression<Func<IQueryable<T>, IQueryable<T>>> aiExpWhenTrue, Expression<Func<IQueryable<T>, IQueryable<T>>> aiExpWhenFalse)
        {
            if (aiCondition)
            {
                SetConditionStr(aiExpWhenTrue, LambdaExpUnion.And);
            }
            else
            {
                SetConditionStr(aiExpWhenFalse, LambdaExpUnion.And);
            }
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where/OrderBy），否则添加后一个
        /// </summary>
        /// <param name="aiCondition">条件</param>
        /// <param name="aiExpWhenTrue">条件为真时</param>
        /// <param name="aiExpWhenFalse">条件为假时</param>
        public void Add(Func<bool> aiCondition, Expression<Func<IQueryable<T>, IQueryable<T>>> aiExpWhenTrue, Expression<Func<IQueryable<T>, IQueryable<T>>> aiExpWhenFalse)
        {
            Add(aiCondition(), aiExpWhenTrue, aiExpWhenFalse);
        }

        #endregion 混合语句增加操作

        #region 以 And 相联接 Where条件语句

        /// <summary>
        /// 添加一个Where条件语句，如果语句存在，则以 And 相联接
        /// </summary>
        /// <param name="aiExp">Where条件表达示</param>
        public void AddAndWhere(Expression<Func<T, bool>> aiExp)
        {
            SetOneConditionStr(aiExp, LambdaExpUnion.And);
        }

        /// <summary>
        /// 当给定条件满足时,添加一个Where条件语句，如果语句存在，则以 And 相联接
        /// </summary>
        /// <param name="aiCondition">给定条件</param>
        /// <param name="aiExp">Where条件表达示</param>
        public void AddAndWhere(bool aiCondition, Expression<Func<T, bool>> aiExp)
        {
            if (aiCondition)
            {
                SetOneConditionStr(aiExp, LambdaExpUnion.And);
            }
        }

        /// <summary>
        /// 当给定lambda表达式条件满足时,添加一个Where条件语句，如果语句存在，则以 And 相联接
        /// </summary>
        /// <param name="aiCondition">给定lambda表达式条件</param>
        /// <param name="aiExp"></param>
        public void AddAndWhere(Func<bool> aiCondition, Expression<Func<T, bool>> aiExp)
        {
            AddAndWhere(aiCondition(), aiExp);
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where），否则添加后一个,以 And 相联接
        /// </summary>
        /// <param name="aiCondition">条件</param>
        /// <param name="aiExpWhenTrue">条件为真时</param>
        /// <param name="aiExpWhenFalse">条件为假时</param>
        public void AddAndWhere(bool aiCondition, Expression<Func<T, bool>> aiExpWhenTrue, Expression<Func<T, bool>> aiExpWhenFalse)
        {
            if (aiCondition)
            {
                SetOneConditionStr(aiExpWhenTrue, LambdaExpUnion.And);
            }
            else
            {
                SetOneConditionStr(aiExpWhenFalse, LambdaExpUnion.And);
            }
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where），否则添加后一个,以 And 相联接
        /// </summary>
        /// <param name="aiCondition">Lambda条件</param>
        /// <param name="aiExpWhenTrue">条件为真时</param>
        /// <param name="aiExpWhenFalse">条件为假时</param>
        public void AddAndWhere(Func<bool> aiCondition, Expression<Func<T, bool>> aiExpWhenTrue, Expression<Func<T, bool>> aiExpWhenFalse)
        {
            AddAndWhere(aiCondition(), aiExpWhenTrue, aiExpWhenFalse);
        }

        #endregion 以 And 相联接 Where条件语句

        #region 以 Or 相联接 Where条件语句

        /// <summary>
        /// 添加一个Where条件语句，如果语句存在，则以 Or 相联接
        /// </summary>
        /// <param name="aiExp">Where条件表达示</param>
        public void AddOrWhere(Expression<Func<T, bool>> aiExp)
        {
            SetOneConditionStr(aiExp, LambdaExpUnion.Or);
        }

        /// <summary>
        /// 当给定条件满足时,添加一个Where条件语句，如果语句存在，则以 Or 相联接
        /// </summary>
        /// <param name="aiCondition">给定条件</param>
        /// <param name="aiExp">Where条件表达示</param>
        public void AddOrWhere(bool aiCondition, Expression<Func<T, bool>> aiExp)
        {
            if (aiCondition)
            {
                SetOneConditionStr(aiExp, LambdaExpUnion.Or);
            }
        }

        /// <summary>
        /// 当给定lambda表达式条件满足时,添加一个Where条件语句，如果语句存在，则以 Or 相联接
        /// </summary>
        /// <param name="aiCondition">给定lambda表达式条件</param>
        /// <param name="aiExp"></param>
        public void AddOrWhere(Func<bool> aiCondition, Expression<Func<T, bool>> aiExp)
        {
            AddOrWhere(aiCondition(), aiExp);
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where），否则添加后一个,以 Or 相联接
        /// </summary>
        /// <param name="aiCondition">条件</param>
        /// <param name="aiExpWhenTrue">条件为真时</param>
        /// <param name="aiExpWhenFalse">条件为假时</param>
        public void AddOrWhere(bool aiCondition, Expression<Func<T, bool>> aiExpWhenTrue, Expression<Func<T, bool>> aiExpWhenFalse)
        {
            if (aiCondition)
            {
                SetOneConditionStr(aiExpWhenTrue, LambdaExpUnion.Or);
            }
            else
            {
                SetOneConditionStr(aiExpWhenFalse, LambdaExpUnion.Or);
            }
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where），否则添加后一个,以 Or 相联接
        /// </summary>
        /// <param name="aiCondition">Lambda条件</param>
        /// <param name="aiExpWhenTrue">条件为真时</param>
        /// <param name="aiExpWhenFalse">条件为假时</param>
        public void AddOrWhere(Func<bool> aiCondition, Expression<Func<T, bool>> aiExpWhenTrue, Expression<Func<T, bool>> aiExpWhenFalse)
        {
            AddOrWhere(aiCondition(), aiExpWhenTrue, aiExpWhenFalse);
        }

        #endregion 以 Or 相联接 Where条件语句

        #region OrderBy语句

        /// <summary>
        /// 添加一个OrderBy语句
        /// </summary>
        /// <typeparam name="TD">OrderBy的字段数据类型</typeparam>
        /// <param name="aiExp">OrderBy条件表达示</param>
        public void AddOrderBy<TD>(Expression<Func<T, TD>> aiExp)
        {
            SetOneConditionStr(aiExp, LambdaExpUnion.OrderBy);
        }

        /// <summary>
        /// 如果条件满足时,添加一个OrderBy语句
        /// </summary>
        /// <typeparam name="TD">OrderBy的字段数据类型</typeparam>
        /// <param name="aiCondition">条件</param>
        /// <param name="aiExp">OrderBy条件表达示</param>
        public void AddOrderBy<TD>(bool aiCondition, Expression<Func<T, TD>> aiExp)
        {
            if (aiCondition)
            {
                SetOneConditionStr(aiExp, LambdaExpUnion.OrderBy);
            }
        }

        /// <summary>
        /// 如果条件满足时,添加一个OrderBy语句
        /// </summary>
        /// <typeparam name="TD">OrderBy的数据字段类型</typeparam>
        /// <param name="aiCondition">Lambda条件</param>
        /// <param name="aiExp">OrderBy条件表达示</param>
        public void AddOrderBy<TD>(Func<bool> aiCondition, Expression<Func<T, TD>> aiExp)
        {
            AddOrderBy<TD>(aiCondition(), aiExp);
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个OrderBy语句，否则添加后一个
        /// </summary>
        /// <typeparam name="TD">OrderBy的数据字段类型</typeparam>
        /// <param name="aiCondition">条件</param>
        /// <param name="aiExpWhenTrue">条件为真时</param>
        /// <param name="aiExpWhenFalse">条件为假时</param>
        public void AddOrderBy<TD>(bool aiCondition, Expression<Func<T, TD>> aiExpWhenTrue, Expression<Func<T, TD>> aiExpWhenFalse)
        {
            if (aiCondition)
            {
                SetOneConditionStr(aiExpWhenTrue, LambdaExpUnion.OrderBy);
            }
            else
            {
                SetOneConditionStr(aiExpWhenFalse, LambdaExpUnion.OrderBy);
            }
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个OrderBy语句，否则添加后一个
        /// </summary>
        /// <typeparam name="TD">OrderBy的数据字段类型</typeparam>
        /// <param name="aiCondition">Lambda条件</param>
        /// <param name="aiExpWhenTrue">条件为真时</param>
        /// <param name="aiExpWhenFalse">条件为假时</param>
        public void AddOrderBy<TD>(Func<bool> aiCondition, Expression<Func<T, TD>> aiExpWhenTrue, Expression<Func<T, TD>> aiExpWhenFalse)
        {
            AddOrderBy<TD>(aiCondition(), aiExpWhenTrue, aiExpWhenFalse);
        }

        #endregion OrderBy语句

        #region 内部操作
        /// <summary>
        /// Where语句
        /// </summary>
        private string _aiWhereStr = string.Empty;
        /// <summary>
        /// OrderBy语句
        /// </summary>
        private string _aiOrderByStr = string.Empty;

        private void SetConditionStr(Expression aiExp, LambdaExpUnion lambdaUion = LambdaExpUnion.And)
        {
            SetWhere(aiExp);//Where条件句

            SetOrderBy(aiExp);//Order by 语句
        }

        private void SetOneConditionStr(Expression aiExp, LambdaExpUnion bizUion = LambdaExpUnion.And)
        {
            if ((bizUion == LambdaExpUnion.And) || (bizUion == LambdaExpUnion.Or))
            {
                SetWhere(aiExp);//Where条件句
            }
            else if (bizUion == LambdaExpUnion.OrderBy)
            {
                SetOrderBy(aiExp);//Order by 语句
            }
        }

        private void SetOrderBy(Expression aiExp)
        {
            var itemstr = ExpressionWriterSql.BizWhereWriteToString(aiExp, SqlType.Order);
            if (string.IsNullOrWhiteSpace(_aiOrderByStr))
            {
                _aiOrderByStr = itemstr;
            }
            else
            {
                _aiOrderByStr = _aiOrderByStr + "," + itemstr;
            }
        }

        private void SetWhere(Expression aiExp, LambdaExpUnion bizUion = LambdaExpUnion.And)
        {
            var itemstr = ExpressionWriterSql.BizWhereWriteToString(aiExp, SqlType.Where);
            if (string.IsNullOrWhiteSpace(_aiWhereStr))
            {
                _aiWhereStr = itemstr;
            }
            else
            {
                if (bizUion == LambdaExpUnion.Or)
                {
                    _aiWhereStr = _aiWhereStr + " Or " + itemstr;
                }
                else
                {
                    _aiWhereStr = _aiWhereStr + " And " + itemstr;
                }
            }
        }

        #endregion 内部操作
    }
}