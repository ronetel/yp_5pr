   M S B A M L   `   `   `  ����>  :DS5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DS5DS5  5          DS5.CheckPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:DS5     5        N� Title$  	CheckPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $
��1.5* �6    � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      �� 5      $
��0.1* �6   .+�5   
   � $��1��6   $��0��6    5      �� 5      �� 5      �� 5      �� 5      �� 5      $��3* �6    .+�5      �� $��Информация:��6   $��0��6+   $��Center=�68   $��20(�6U   
���   �6c   �� 5      -   5         ��Name$	 emp��5      $��Сотрудник:��6%   $��1��67   $��Center=�6D   $��16(�6a   
���   �6o   �� 5      -   5        $
 date��5      $��	Дата:��6&   $��2��63   $��Center=�6@   $��16(�6]   
���   �6k   �� 5       -   5        $
 summ��5       $��Сумма:��6&   $��3��64   $��Center=�6A   $��16(�6^   
���   �6l   5!      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ 
grid_check��5$      $��1��6'   $��1��64      
IsReadOnly .    AutoGenerateColumns .     Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6F   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 2* 6X   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *name_product+6X     5'      $ Цена��6?   $
	 1.5* 6M   
 6%   �� *price+6M     5(      $ Тип продукта��6F   $
	 1.5* 6\   
 6%   �� *product_type+6\   5*      �� 5+   
   $��Выгрузить��6   $��2��6%   $��2��69   �� 5,   
   -   5         ��Name$ checks��5,      $��2��6#   $��0��67   6D   5-      5.      