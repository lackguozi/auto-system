namespace LuckCode.Model
{
    public class MessageEntity<T>
    {
        public static MessageEntity<T> Success(string msg)
        {
            return Message(true, msg, default,200);
        }
        public bool success { get; set; }
        public int code { get; set; } = 200;
        public string message { get; set; }
        public T data  { get; set; }
        public static MessageEntity<T> Fail(string msg, int code)
        {
            return Message(false, msg, default,code);
        }
        public static MessageEntity<T> Message(bool success, string msg, T response,int code)
        {
            return new MessageEntity<T>() { message = msg, data = response, success = success,code =200};
        }
    }
    public class MessageModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 200;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string messsage { get; set; } = "";
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public object data { get; set; }
    }
}
