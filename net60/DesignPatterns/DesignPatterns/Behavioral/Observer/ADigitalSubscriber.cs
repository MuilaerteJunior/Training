namespace DesignPatterns.Behavioral.Observer
{
    public class ADigitalSubscriber : IObserverT<Topic>
    {
        private Topic _tclass;


        void IObserverT<Topic>.Update(Topic tclass)
        {
            this._tclass = tclass;
        }

        public string GetInformationFromTopic(){
            return this._tclass.CurrentContent;
        }
    }
}