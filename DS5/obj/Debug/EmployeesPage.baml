   M S B A M L   `   `   `  ����>  :DS5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DS5DS5  5          DS5.EmployeesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:DS5     5        N� Title$  EmployeesPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   � $��1��6   $��3��6    5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$
 TxB1��5      $��0��6%   $��Center=�65   �� 5      -   5        $
 TxB2��5      $��1��6%   $��Center=�65   �� 5       -   5        $
 TxB3��5       $��2��6%   $��Center=�65   �� 5!      -   5         ��Name$ 	Combobox1��5!      $��3��6+   $��Center=�6;   �� 5"      -   5        $ 	Combobox2��5"      $��4��6+   $��Center=�6;   5#      �� 5$   
   -   5        $��Добавить��5$      $��2��6$   $��0��61   6A   �� 5%   
   -   5        $��Изменить��5%      $��2��6$   $��1��61   6A   �� 5&   
   -   5        $��Удалить��5&      $��2��6#   $��2��60   6@   &   System.Windows.Controls.DataGrid  5'   
   -	   5          Name$
 grid��5'      $��0��6!   $��3��6.      
IsReadOnly .    AutoGenerateColumns .     Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Имя��6B   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *
name_emp+6B     5*      $	 Фамилия��6E   
 6%   �� *surname_emp+6E     5+      $	 Отчество��6F   
 6%   �� *midlname_emp+6F     5,      $	 Аккаунт��6G   
 6%   �� *login_account+6G     5-      $	 Паспорт��6@   
 6%   �� *series+6@   5/      50      51      