   M S B A M L   `   `   `  ����>  :DS5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DS5DS5  5          DS5.PassportPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:DS5     5        N� Title$  PassportPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   � $��1��6   $��3��6    5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$
 TxB1��5      $��0��6%   $��Center=�65    �� 	MaxLength$ 4��6P   �� 5      -   5        $
 TxB2��5      $��1��6%   $��Center=�65   �� 5       -   5        $
 TxB3��5       $��2��6%   $��Center=�65   �� 5!      -   5        $
 TxB4��5!      $��3��6%   $��Center=�65   �� 5"      -   5        $
 TxB5��5"      $��4��6%   $��Center=�65   5#      �� 5$   
   -   5        $��Добавить��5$      $��2��6$   $��0��61   6A   �� 5%   
   -   5        $��Изменить��5%      $��2��6$   $��1��61   6A   �� 5&   
   -   5        $��Удалить��5&      $��2��6#   $��2��60   6@   &   System.Windows.Controls.DataGrid  5'   
   -	   5          Name$
 grid��5'      $��0��6!   $��3��6.      
IsReadOnly .    AutoGenerateColumns .     Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Серия��6@   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *series+6@     5*      $	 
Номер��6A   
 6%   �� *	numbers+6A     5+      $	 Кем выдан��6@   
 6%   �� *issued+6@     5,      $'	 !Код подразделения��6I   
 6%   �� *department_code+6I     5-      $	 Дата выдачи��6H   
 6%   �� *date_of_issued+6H   5/      50      51      