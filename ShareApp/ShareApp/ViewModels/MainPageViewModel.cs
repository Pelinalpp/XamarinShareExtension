using ShareApp.Helper;
using ShareApp.Models;
using System.Collections.Generic;

namespace ShareApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel, IAppStateAware
    {
        private List<string> itemList;
        public List<string> ItemList { get => itemList; set { SetValue(ref itemList, value); } }

        public void OnResumeApplicationAsync()
        {
            ItemList = Datas.SharedItems;
        }
    }
}
