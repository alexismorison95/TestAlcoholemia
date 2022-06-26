import { AfterViewInit, Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Tipousuario } from '../../../interfaces/Tipousuario';

@Component({
  selector: 'tipo-usuarios-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit, AfterViewInit, OnChanges {

  //inputs
  @Input() pTipoUsuarios: Tipousuario[] = [];

  //tabla
  displayedColumns: string[] = ['tipo', 'actions'];
  dataSource: MatTableDataSource<Tipousuario>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() { 

    this.dataSource = new MatTableDataSource(this.pTipoUsuarios);
  }

  ngOnChanges(changes: SimpleChanges): void {
    
    this.dataSource = new MatTableDataSource(this.pTipoUsuarios);

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngAfterViewInit(): void {

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
  }

  /**
   * Aplica el filtro de la tabla a los datos
   * @param event 
   */
  applyFilter(event: Event): void {

    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
