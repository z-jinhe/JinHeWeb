﻿using System.Text;
using System.Web.Mvc;

namespace JinHeMilk
{
    public static class ExtendMethod
    {
        
        public static JsonNetResult JsonNet(this Controller controller, object data)
        {
            return JsonNet(data, null, null, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 创建一个将指定对象序列化为 JavaScript 对象表示法 (JSON) 格式的 <see cref="T:System.Web.Mvc.JsonNetResult"/> 对象。
        /// </summary>
        /// 
        /// <returns>
        /// 将指定对象序列化为 JSON 格式的 JSON 结果对象。
        /// </returns>
        /// <param name="controller">控件器</param>
        /// <param name="data">要序列化的 JavaScript 对象图。</param>
        /// <param name="contentType">内容类型（MIME 类型）。</param>
        public static JsonNetResult JsonNet(this Controller controller, object data, string contentType)
        {
            return JsonNet(data, contentType, null, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 创建一个将指定对象序列化为 JavaScript 对象表示法 (JSON) 格式的 <see cref="T:System.Web.Mvc.JsonNetResult"/> 对象。
        /// </summary>
        /// 
        /// <returns>
        /// 将指定对象序列化为 JSON 格式的 JSON 结果对象。
        /// </returns>
        /// <param name="controller">控件器</param>
        /// <param name="data">要序列化的 JavaScript 对象图。</param>
        /// <param name="contentType">内容类型（MIME 类型）。</param>
        /// <param name="contentEncoding">内容编码。</param>
        public static JsonNetResult JsonNet(this Controller controller, object data, string contentType,
            Encoding contentEncoding)
        {
            return JsonNet(data, contentType, contentEncoding, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 创建 <see cref="T:System.Web.Mvc.JsonNetResult"/> 对象，该对象使用指定 JSON 请求行为将指定对象序列化为 JavaScript 对象表示法 (JSON) 格式。
        /// </summary>
        /// 
        /// <returns>
        /// 将指定对象序列化为 JSON 格式的结果对象。
        /// </returns>
        /// <param name="controller">控件器</param>
        /// <param name="data">要序列化的 JavaScript 对象图。</param>
        /// <param name="behavior">JSON 请求行为。</param>
        public static JsonNetResult JsonNet(this Controller controller, object data, JsonRequestBehavior behavior)
        {
            return JsonNet(data, null, null, behavior);
        }

        /// <summary>
        /// 创建 <see cref="T:System.Web.Mvc.JsonNetResult"/> 对象，该对象使用指定内容类型和 JSON 请求行为将指定对象序列化为 JavaScript 对象表示法 (JSON) 格式。
        /// </summary>
        /// 
        /// <returns>
        /// 将指定对象序列化为 JSON 格式的结果对象。
        /// </returns>
        /// <param name="controller">控件器</param>
        /// <param name="data">要序列化的 JavaScript 对象图。</param>
        /// <param name="contentType">内容类型（MIME 类型）。</param>
        /// <param name="behavior">JSON 请求行为</param>
        public static JsonNetResult JsonNet(this Controller controller, object data, string contentType,
            JsonRequestBehavior behavior)
        {
            return JsonNet(data, contentType, null, behavior);
        }

        /// <summary>
        /// 创建 <see cref="T:System.Web.Mvc.JsonNetResult"/> 对象，该对象使用内容类型、内容编码和 JSON 请求行为将指定对象序列化为 JavaScript 对象表示法 (JSON) 格式。
        /// </summary>
        /// 
        /// <returns>
        /// 将指定对象序列化为 JSON 格式的结果对象。
        /// </returns>
        /// <param name="controller">控件器</param>
        /// <param name="data">要序列化的 JavaScript 对象图。</param>
        /// <param name="contentType">内容类型（MIME 类型）。</param>
        /// <param name="contentEncoding">内容编码。</param><param name="behavior">JSON 请求行为</param>
        public static JsonNetResult JsonNet(this Controller controller, object data, string contentType,
            Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return JsonNet(data, contentType, contentEncoding, behavior);
        }

        /// <summary>
        /// 创建 <see cref="T:System.Web.Mvc.JsonNetResult"/> 对象，该对象使用内容类型、内容编码和 JSON 请求行为将指定对象序列化为 JavaScript 对象表示法 (JSON) 格式。
        /// </summary>
        /// <param name="data">要序列化的 JavaScript 对象图。</param>
        /// <param name="contentType">内容类型（MIME 类型）。</param>
        /// <param name="contentEncoding">内容编码。</param>
        /// <param name="behavior"></param>
        /// <returns>JSON 请求行为</returns>
        private static JsonNetResult JsonNet(object data, string contentType, Encoding contentEncoding,
            JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}
