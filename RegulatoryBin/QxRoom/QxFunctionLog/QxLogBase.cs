namespace QxRoom.QxFunctionLog
{
    using System;

    [Serializable]
    public abstract class QxLogBase
    {
        protected QxLogBase()
        {
        }

        public abstract string FunctionId { get; set; }

        public abstract string Id { get; set; }

        public abstract string UserId { get; set; }
    }
}

