   M S B A M L   `   `   `  ����I  ESQLiteExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SQLiteExplorer.ViewSQLiteExplorer.View  5   	   C&clr-namespace:SQLiteExplorer.ViewModelSQLiteExplorer.ViewModel  5   	   9!clr-namespace:SQLiteExplorer.MVVMSQLiteExplorer.MVVM  5   	   (    "SQLiteExplorer.View.MainWindowView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SQLiteExplorer.View     5   	   <	ViewModel&clr-namespace:SQLiteExplorer.ViewModel     5   	   2MVVM!clr-namespace:SQLiteExplorer.MVVM     5   	     � Title$  MainWindowView��5
   	    � 	Resources 5      '   !SQLiteExplorer.MVVM.ViewConverter   viewAdapter��%   &	          5   
   64   5       � DataContext 5      2  ,SQLiteExplorer.ViewModel.MainWindowViewModel  5   
   6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $	��320��6    $	��320 �6/   6=   �� 5      $��5 �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5   
   o� $��0��6   $��4��6   .@�5      m� $
��File��6   6'   m� 5      $
��File��6   6'   m� 5       $
��File��6   6'   m� 5!      $
��File��6   6'   5"      �� 5#   
   $��1��6    �� DragIncrement$ 2Q�6'   $��Center=�69   $��1��6V   $��5��6c   6o   �� 5$   
   $��1��6   $��0��6&   ��66   �� *ObjectExplorer+ �� 	Converter# [  6�   � 5%   
   $��1��6   $��2��6   6.   5&      5'      