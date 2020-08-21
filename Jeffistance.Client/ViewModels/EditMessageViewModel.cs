using ReactiveUI;
using System.Reactive;

namespace Jeffistance.Client.ViewModels
{
    public class EditMessageViewModel : ViewModelBase
    {
        private string _username;
        private string _id;
        private ChatViewModel _parent;
        public EditMessageViewModel(string id, string messageText, ChatViewModel parent, string username)
        {
            _username = username;
            _parent = parent;
            _id = id;
            MessageContent = messageText;
            var okEnabled = this.WhenAnyValue(
                x => x.MessageContent,
                x => !string.IsNullOrWhiteSpace(x));

            OnOkClicked = ReactiveCommand.Create(OnOkClickedMethod, okEnabled);

            OnCancelClicked = ReactiveCommand.Create(() => { });
        }

        string messageContent;
       
        public string MessageContent {
            get => messageContent;
            set => this.RaiseAndSetIfChanged(ref messageContent, value);
        }

        public ReactiveCommand<Unit, ChatMessageViewModel> OnOkClicked { get; }
        public ReactiveCommand<Unit, Unit> OnCancelClicked { get; }

        public ChatMessageViewModel OnOkClickedMethod(){
            return new ChatMessageViewModel (_id, MessageContent, _parent, _username);
        }

    }
}