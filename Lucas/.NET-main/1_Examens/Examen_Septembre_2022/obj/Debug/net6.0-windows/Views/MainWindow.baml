   M S B A M L   `   `   `  ����P  LExamen_Septembre_2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Examen_Septembre_2022Examen_Septembre_2022  5   	   &     Examen_Septembre_2022.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Examen_Septembre_2022     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5
         listboxTemplate �� Orientation��%�   &	        �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� ��6   �� *	ProductId+�� 5      ��6   �� *ProductName+5      5      5      .��5      � .+�5   
   �� -   5         ��Name$ listBoxProducts��5      $��0,10,488,334q�5   7   #��[  5      ��5      �� *ProductsList+ �� SelectedItem 5      �� *SelectedProduct+ �� UpdateSourceTrigger$ PropertyChanged=�� 5   
    � DataContext 6   �� *SelectedItem+ �� ElementName$ listBoxProducts��.+�5      �� $��ProductID : ��6   $
��Left=�6+   $��
10,140,0,0q�6F   $	��Top=�6Z   �� 5      $��ProductName :��6   $
��Left=�6,   $��
10,171,0,0q�6G   $	��Top=�6[   �� 5      $��QuantityPerUnit :��6   $
��Left=�60   $��
10,209,0,0q�6K   $	��Top=�6_   �� 5      $��Fournisseur :��6   $
��Left=�6,   $��
10,240,0,0q�6G   $	��Top=�6[   �� 5!      $
��Left=�6W   $	��247��6r   $��
92,140,0,0q�6~   $	��Top=�6�   $��32��6�   ��6   �� *	ProductId+$ PropertyChanged=�6�   �� 5"      $
��Left=�6X   $	��159��6s   $��113,171,0,0q�6   $	��Top=�6�   $��32��6�   ��6   �� *ProductName+$ PropertyChanged=�6�   �� 5#      $
��Left=�6U   $	��159��6p   $��
92,206,0,0q�6|   $	��Top=�6�   $��32��6�   ��6   �� *
Quantity+$ PropertyChanged=�6�   �� 5$      $
��Left=�6Y   $	��159��6t   $��
92,238,0,0q�6�   $	��Top=�6�   $��32��6�   ��6   �� *Fournisseur+$ PropertyChanged=�6�   &   System.Windows.Controls.DataGrid  5&      -   5          Name$ dataGridProductSales��5&      $��477,24,34,24q�65   ��5'      �� *DataContext.ProductsPrice+	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType"
 �   Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ProductId��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	ProductId+  5+      $ 
TotalPrice��6)    6=   �� *
TotalPrice+5-      5.      �� 50   
   $	��MAJ��6   $��67,297,673,95q�6A   ��6   �� *UpdateCommand+6A   54      55      