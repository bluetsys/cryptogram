﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using cryptogram.Models;
using cryptogram.ViewModels;

namespace cryptogram.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ItemDetailPage : ContentPage
  {
    ItemDetailViewModel viewModel;

    public ItemDetailPage(ItemDetailViewModel viewModel)
    {
      InitializeComponent();
      Messages = this.FindByName<StackLayout>("MessageList");
      BindingContext = this.viewModel = viewModel;
      string PublicKeys = PublicKey.Text + " " + Core.Functions.GetMyPublicKey();
      var Keys = PublicKeys.Split(' ');
      cryptogram.Core.Messaging.Participants = new System.Collections.Generic.List<string>(Keys);
    }

    public static StackLayout Messages;

    public ItemDetailPage()
    {
      InitializeComponent();

      var item = new Item
      {
        ContactName = "Not name set",
        PublicKey = "Not pubblic key set"
      };

      viewModel = new ItemDetailViewModel(item);
      BindingContext = viewModel;
    }

    private void Send_Clicked(object sender, EventArgs e)
    {
      Core.Messaging.SendText(TextMessage.Text);
    }



  }
}