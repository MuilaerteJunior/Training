namespace DesignPatterns.Behavioral.Observer
{
    public class Subscriber : IObserverT<Topic>
    {
        private Topic _tclass;

        public Subscriber()
        {
        }

        void IObserverT<Topic>.Update(Topic tclass)
        {
            this._tclass = tclass;
        }

        public string GetInformationFromTopic(){
            return this._tclass.CurrentContent;
        }
    }
}