   M S B A M L   `   `   `  ����>  :DS5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DS5DS5  5          DS5.ProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:DS5     5        N� Title$  ProductPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   � $��1��6   $��3��6    5      �� 5      �� 5      �� 5       5      �� 5      �� 5      5       � 5!   
   $��1��6   $��3��6    5"      �� 5#      �� 5$      �� 5%      .+�5'      �� -   5         ��Name$
 TxB1��5'      $��0��6%   $��Center=�65   �� 5(      -   5        $
 TxB2��5(      $��1��6%   $��Center=�65   �� 5)      -   5         ��Name$ 	Combobox1��5)      $��2��6+   $��Center=�6;   5*      �� 5+   
   -   5        $��Добавить��5+      $��2��6$   $��0��61   6A   �� 5,   
   -   5        $��Изменить��5,      $��2��6$   $��1��61   6A   �� 5-   
   -   5        $��Удалить��5-      $��2��6#   $��2��60   6@   &   System.Windows.Controls.DataGrid  5.   
   -   5          Name$
 grid��5.      $��0��6!   $��3��6.      
IsReadOnly .    AutoGenerateColumns .     Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Название��6F   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 2* 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *name_product+6X     51      $	 Цена��6?   $

 1.5* 6M    6%   �� *price+6M     52      $	 Тип продукта��6F   $

 1.5* 6\    6%   �� *product_type+6\   54      55      56      