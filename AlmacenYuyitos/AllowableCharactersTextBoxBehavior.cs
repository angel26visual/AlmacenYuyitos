using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace AlmacenYuyitos.Behaviors
{
    public class AllowableCharactersTextBoxBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty RegularExpressionProperty =
            DependencyProperty.Register("RegularExpression", typeof(string), typeof(AllowableCharactersTextBoxBehavior),
                new FrameworkPropertyMetadata(".*"));
        public string RegularExpresion
        {
            get
            {
                return (string)base.GetValue(RegularExpressionProperty);
            }
            set
            {
                base.SetValue(RegularExpressionProperty, value);
            }
        }

        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register("MaxLength", typeof(int), typeof(AllowableCharactersTextBoxBehavior),
                new FrameworkPropertyMetadata(int.MinValue));
        public int MaxLength
        {
            get
            {
                return (int)base.GetValue(MaxLengthProperty);
            }
            set
            {
                base.SetValue(MaxLengthProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += OnPreviewTextInput;
            DataObject.AddPastingHandler(AssociatedObject, OnPaste);
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
                if(!IsValid(text, true))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(e.Text, false);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
            DataObject.RemovePastingHandler(AssociatedObject, OnPaste);
        }

        private bool IsValid(string newtext, bool paste)
        {
            return !ExceedsMaxLength(newtext, paste) && Regex.IsMatch(newtext, RegularExpresion);
        }

        private bool ExceedsMaxLength(object newText, bool paste)
        {
            if (MaxLength == 0) return false;
            return LengthOfModifiedText(newText, paste) > MaxLength;
        }

        private int LengthOfModifiedText(object newText, bool paste)
        {
            var countOfSelectedChars = this.AssociatedObject.SelectedText.Length;
            var caretIndex = this.AssociatedObject.CaretIndex;
            return 1;
        }
    }
}
