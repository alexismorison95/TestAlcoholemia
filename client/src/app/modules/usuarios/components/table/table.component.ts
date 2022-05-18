import { Component, OnInit, ViewChild, AfterViewInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { GetUsuarioDTO } from '../../interfaces/Usuarios';

@Component({
  selector: 'usuarios-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit, AfterViewInit, OnChanges {
  @Input() pUsuarios: GetUsuarioDTO[] = [];

  displayedColumns: string[] = ['nombreusuario', 'activo', 'nombrereal', 'tipousuario'];
  dataSource: MatTableDataSource<GetUsuarioDTO>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() { 

    this.dataSource = new MatTableDataSource(this.pUsuarios);
  }

  ngOnChanges(changes: SimpleChanges): void {
    
    this.dataSource = new MatTableDataSource(this.pUsuarios);
  }

  ngAfterViewInit() {

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
  }

  applyFilter(event: Event) {

    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
