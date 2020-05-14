using ISFileAndContent.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ISFileAndContent.FolderUtil
{
    public static class FileHelper
    {
        /// <summary>
        /// 文件智能搜索
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Q"></typeparam>
        /// <param name="queryableData">数据集合</param>
        /// <param name="queryCondtion">查询条件</param>
        /// <param name="orderbyItem">排序集合</param>
        /// <returns></returns>
        public static DataCollection<T> FileIntelligentSearch<T, Q>(IQueryable<T> queryableData, Q queryCondtion, params OrderByDto[] orderbyItem) where Q : PageDto where T : class
        {
            DataCollection<T> dc = new DataCollection<T>();

            Expression left;
            Expression right;
            Expression where;
            List<ParameterExpression> leftList = new List<ParameterExpression>();
            List<Expression> whereList = new List<Expression>();
            ParameterExpression pe = Expression.Parameter(typeof(T), "n");

            PropertyInfo[] dataPropertys = typeof(T).GetProperties();

            PropertyInfo[] propertys = queryCondtion.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                //判断string类型
                if (pi.PropertyType == typeof(String))
                {
                    var obj = pi.GetValue(queryCondtion, null);
                    if (string.IsNullOrEmpty(Convert.ToString(obj)))
                        continue;

                    PropertyInfo isExistPi = dataPropertys.Where(n => n.Name == pi.Name).FirstOrDefault();

                    //过滤掉无值属性
                    if (obj != null && isExistPi != null)
                    {
                        //创建参数
                        left = Expression.Property(pe, typeof(T).GetProperty(pi.Name));

                        //创建表达
                        string value = obj.ToString();
                        right = Expression.Constant(value.ToLower());

                        //字符串模糊搜索需要使用call方法
                        where = Expression.Call(
                            left,
                            typeof(string).GetMethod("Contains"),
                            right);

                        whereList.Add(where);

                    }
                }

                //判断 int 
                if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(Enum))
                {
                    var obj = pi.GetValue(queryCondtion, null);
                    PropertyInfo isExistPi = dataPropertys.Where(n => n.Name == pi.Name).FirstOrDefault();

                    if (obj != null && Convert.ToInt32(obj) > 0 && isExistPi != null)
                    {
                        //创建参数
                        left = Expression.Property(pe, typeof(T).GetProperty(pi.Name));

                        //创建表达
                        int value = Convert.ToInt32(obj);
                        right = Expression.Constant(value);

                        where = Expression.Equal(left, right);

                        whereList.Add(where);
                    }
                }

                //判断 datetime
                if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?))
                {
                    var obj = pi.GetValue(queryCondtion, null);

                    PropertyInfo startPi = dataPropertys.Where(n => pi.Name.Remove(5).ToLower() == "start" && pi.Name.Substring(5) == n.Name).FirstOrDefault();
                    PropertyInfo endPi = dataPropertys.Where(n => pi.Name.Remove(3).ToLower() == "end" && pi.Name.Substring(3) == n.Name).FirstOrDefault();

                    if (obj != null && (startPi != null || endPi != null))
                    {
                        if (startPi != null)
                        {
                            //创建参数
                            left = Expression.Property(pe, typeof(T).GetProperty(startPi.Name));

                            //创建表达
                            if (startPi.PropertyType == typeof(DateTime))
                            {
                                DateTime value = Convert.ToDateTime(obj);
                                right = Expression.Constant(value);
                            }
                            else
                            {
                                DateTime? value = ((DateTime?)obj).Value;
                                right = Expression.Constant(value);
                            }
                            where = Expression.GreaterThanOrEqual(left, right);
                        }
                        else
                        {
                            //创建参数
                            left = Expression.Property(pe, typeof(T).GetProperty(endPi.Name));

                            //创建表达
                            object value = ((DateTime?)obj).Value;
                            right = Expression.Constant(value);

                            where = Expression.LessThan(left, right);
                        }

                        whereList.Add(where);
                    }
                }

            }

            //分页默认值
            queryCondtion.Page = queryCondtion.Page == 0 ? 1 : queryCondtion.Page;
            queryCondtion.PageSize = queryCondtion.PageSize == 0 ? 10 : queryCondtion.PageSize;

            Expression whereAll;

            if (whereList.Count > 0)
            {
                whereAll = whereList[0];
                for (int i = 1; i < whereList.Count; i++)
                {
                    whereAll = Expression.And(whereAll, whereList[i]);
                }
            }
            else
            {
                whereAll = Expression.Equal(Expression.Constant(1), Expression.Constant(1));
            }

            //where
            MethodCallExpression whereCallExpression = Expression.Call(
           typeof(Queryable),
           "Where",
           new Type[] { queryableData.ElementType },
           queryableData.Expression,
           Expression.Lambda<Func<T, bool>>(whereAll, new ParameterExpression[] { pe }));

            MethodCallExpression orderByExpression = null;
            int index = 0;
            if (orderbyItem.Length > 0)
            {
                foreach (var item in orderbyItem)
                {
                    index++;
                    OrderByDto orderbyEntity = item as OrderByDto;
                    string sortname = orderbyEntity.SortName;
                    bool desc = orderbyEntity.Desc;
                    string OrderbyKey = desc ? "OrderByDescending" : "OrderBy";

                    Expression lambdaExpression = null;

                    //排序
                    //orderby sortname
                    left = Expression.Property(pe, typeof(T).GetProperty(sortname));
                    if (orderbyEntity.t == typeof(int))
                    {
                        lambdaExpression = Expression.Lambda<Func<T, int>>(left, new ParameterExpression[] { pe });
                    }
                    else if ((orderbyEntity.t == typeof(DateTime) || orderbyEntity.t == typeof(DateTime?)))
                    {
                        lambdaExpression = Expression.Lambda<Func<T, DateTime>>(left, new ParameterExpression[] { pe });
                    }
                    else if (orderbyEntity.t == typeof(string))
                    {
                        lambdaExpression = Expression.Lambda<Func<T, string>>(left, new ParameterExpression[] { pe });
                    }
                    else
                    {
                        lambdaExpression = Expression.Lambda<Func<T, string>>(left, new ParameterExpression[] { pe });
                    }


                    if (index == 1)
                    {
                        orderByExpression = Expression.Call(
                            typeof(Queryable),
                             OrderbyKey,
                             new Type[] { queryableData.ElementType, orderbyEntity.t },
                             whereCallExpression,
                             lambdaExpression);
                    }
                    else
                    {
                        orderByExpression = Expression.Call(
                            typeof(Queryable),
                             OrderbyKey,
                             new Type[] { queryableData.ElementType, orderbyEntity.t },
                             orderByExpression,
                             lambdaExpression);
                    }


                }
            }
            else
            {
                //无排序
                orderByExpression = whereCallExpression;
            }

            IQueryable<T> results = queryableData.Provider.CreateQuery<T>(orderByExpression);

            //分页
            //总数、总页数
            int totalCount = results.Count();
            int pageCount = Convert.ToInt32(System.Math.Ceiling(Convert.ToDecimal(totalCount) / queryCondtion.PageSize));

            List<T> pageList = results.Skip(queryCondtion.PageSize * (queryCondtion.Page - 1)).Take(queryCondtion.PageSize).ToList();

            dc.data = pageList;
            dc.Page = queryCondtion.Page;
            dc.PageSize = queryCondtion.PageSize;
            dc.PageCount = pageCount;
            dc.TotalCount = totalCount;
            return dc;

            #region 注释掉
            //if (whereList.Count > 0)
            //{
            //    whereAll = whereList[0];
            //    for (int i = 1; i < whereList.Count; i++)
            //    {
            //        whereAll = Expression.And(whereAll, whereList[i]);
            //    }

            //    //where
            //    MethodCallExpression whereCallExpression = Expression.Call(
            //   typeof(Queryable),
            //   "Where",
            //   new Type[] { queryableData.ElementType },
            //   queryableData.Expression,
            //   Expression.Lambda<Func<T, bool>>(whereAll, new ParameterExpression[] { pe }));

            //    //排序
            //    //orderby Status
            //    left = Expression.Property(pe, typeof(T).GetProperty("Status"));

            //    MethodCallExpression orderByStatusExpression = Expression.Call(
            //    typeof(Queryable),
            //    "OrderBy",
            //    new Type[] { queryableData.ElementType, typeof(int) },
            //    whereCallExpression,
            //    Expression.Lambda<Func<T, int>>(left, new ParameterExpression[] { pe }));

            //    //orderby FileOn desc
            //    left = Expression.Property(pe, typeof(T).GetProperty("FileOn"));
            //    MethodCallExpression orderByFileOnExpression = Expression.Call(
            //        typeof(Queryable),
            //        "OrderByDescending",
            //         new Type[] { queryableData.ElementType, typeof(DateTime) },
            //         orderByStatusExpression,
            //         Expression.Lambda<Func<T, DateTime>>(left, new ParameterExpression[] { pe }));

            //    IQueryable<T> results = queryableData.Provider.CreateQuery<T>(orderByFileOnExpression);

            //    //分页
            //    //总数、总页数
            //    int totalCount = results.Count();
            //    int pageCount = Convert.ToInt32(System.Math.Ceiling(Convert.ToDecimal(totalCount) / queryCondtion.PageSize));

            //    List<T> pageList = results.Skip(queryCondtion.PageSize * (queryCondtion.Page - 1)).Take(queryCondtion.PageSize).ToList();

            //    dc.data = pageList;
            //    dc.Page = queryCondtion.Page;
            //    dc.PageSize = queryCondtion.PageSize;
            //    dc.PageCount = pageCount;
            //    dc.TotalCount = totalCount;
            //    return dc;
            //}
            //else
            //{


            #region 无查询条件 有参考价值
            //    //无查询条件
            //    //orderby Status
            //    left = Expression.Property(pe, typeof(T).GetProperty("Status"));

            //    MethodCallExpression orderByStatusExpression = Expression.Call(
            //    typeof(Queryable),
            //    "OrderBy",
            //    new Type[] { queryableData.ElementType, typeof(int) },
            //    queryableData.Expression, //有参考价值
            //    Expression.Lambda<Func<T, int>>(left, new ParameterExpression[] { pe }));
            #endregion

            //    //排序
            //    //orderby FileOn desc
            //    left = Expression.Property(pe, typeof(T).GetProperty("FileOn"));
            //    MethodCallExpression orderByFileOnExpression = Expression.Call(
            //        typeof(Queryable),
            //        "OrderByDescending",
            //         new Type[] { queryableData.ElementType, typeof(DateTime) },
            //         orderByStatusExpression,
            //         Expression.Lambda<Func<T, DateTime>>(left, new ParameterExpression[] { pe }));

            //    IQueryable<T> results = queryableData.Provider.CreateQuery<T>(orderByFileOnExpression);

            //    //分页
            //    //总数、总页数
            //    int totalCount = results.Count();
            //    int pageCount = Convert.ToInt32(System.Math.Ceiling(Convert.ToDecimal(totalCount) / queryCondtion.PageSize));

            //    List<T> pageList = results.Skip(queryCondtion.PageSize * (queryCondtion.Page - 1)).Take(queryCondtion.PageSize).ToList();

            //    dc.data = pageList;
            //    dc.Page = queryCondtion.Page;
            //    dc.PageSize = queryCondtion.PageSize;
            //    dc.PageCount = pageCount;
            //    dc.TotalCount = totalCount;
            //    return dc;
            //}

            #endregion
        }

        public static List<FileInfo> GetAllFiles(string folderPath)
        {
            List<DirectoryInfo> dirList = new List<DirectoryInfo>();
            List<FileInfo> fileList = new List<FileInfo>();

            return GetFoldersLoop(folderPath,dirList,fileList);

        }

        private static List<FileInfo> GetFoldersLoop(string path, List<DirectoryInfo> dirList, List<FileInfo> fileList)
        {
            //List<DirectoryInfo> diList = new List<DirectoryInfo>();
            //List<FileInfo> fileList = new List<FileInfo>();
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                //收集文件
                FileInfo[] fis = GetFiles(dir.FullName);
                if (fis != null && fis.Length > 0)
                {
                    fileList.AddRange(fis);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                if (dirs.Length > 0)
                {
                    dirList.AddRange(dirs);
                    foreach (var item in dirs)
                    {
                        GetFoldersLoop(item.FullName, dirList, fileList);
                    }
                }
            }
            return fileList;

        }

        private static FileInfo[] GetFiles(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                return dir.GetFiles();
            }
            return null;

        }


        /// <summary>
        /// 读取文本文件可以打开的文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadTxtFile(string filePath)
        {
            int counter = 0;//文件行数
            string line;//文件行内容
            StringBuilder fileContent = new StringBuilder();//文件内容

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                fileContent.Append(line);
                counter++;
            }

            file.Close();
            return fileContent.ToString();
        }
    }
}
