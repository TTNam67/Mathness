namespace ObserverPattern
{
    public interface IObserver
    {
        public void OnNotify();

        /*Type of parameter on OnNotify() can vary based on the requirements of the specific project and 
        what data the observers might need 
        */
        // public void OnNotify(int id);
        // public void OnNotify(string action);
        // public void OnNotify(Data eventData);
    }
}