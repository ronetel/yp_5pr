   M S B A M L   `   `   `  ����>  :DS5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DS5DS5  5   	       DS5.EmploeeysWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:DS5     5   	     � Title$  EmploeeysWindow��5   	   $	��450��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $��2* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��Статус заказа��6    �� TextAlignment$ Center=�6)   $��1��6@   $��3��6M   �� 5   
   -   5         ��Name$ status��5      $��2��6#   $��3��60   $��Center=�6@   �� 5   
   -   5        $��
Выход��5      $��2��6!   $��0��6.   6>   �� 5   
   -   5        $��Изменить��5      $��2��6$   $��1��61   6A   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
grid_order��5      $��0��6'   $��3��64      
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Номер заказа��6B   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *
ID_order+6B     5      $	 Статус��6F   
 6%   �� *status_order+6F     5      $	 Имя клиента��6E   
 6%   �� *name_client+6E   5      5       5!      