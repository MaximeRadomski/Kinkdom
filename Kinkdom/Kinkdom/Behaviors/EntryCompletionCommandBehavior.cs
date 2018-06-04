using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kinkdom.Behaviors
{
    public class EntryCompletionCommandBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty CustomCommandProperty =
            BindableProperty.Create("CustomCommand", typeof(ICommand), typeof(EntryCompletionCommandBehavior), null);

        public static readonly BindableProperty TestLabelProperty =
            BindableProperty.Create("TestLabel", typeof(string), typeof(EntryCompletionCommandBehavior), null);

        public string TestLabel
        {
            get => (string)GetValue(TestLabelProperty);
            set => SetValue(TestLabelProperty, value);
        }

        public ICommand CustomCommand
        {
            get => (ICommand)GetValue(CustomCommandProperty);
            set => SetValue(CustomCommandProperty, value);
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.Completed += OnEntryCompletion;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Completed -= OnEntryCompletion;
            base.OnDetachingFrom(entry);
        }

        void OnEntryCompletion(object sender, EventArgs args)
        {
            if (TestLabel == null)
                return;
            if (CustomCommand == null) return;
            if (CustomCommand.CanExecute(null))
            {
                CustomCommand.Execute(null);
            }
        }
    }
}