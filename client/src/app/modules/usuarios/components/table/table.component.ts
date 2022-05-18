import { Component, OnInit, ViewChild, AfterViewInit, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
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

  @Output() addUsuarioEvent = new EventEmitter();
  @Output() editUsuarioEvent = new EventEmitter<GetUsuarioDTO>();
  @Output() deleteUsuarioEvent = new EventEmitter<string>();

  displayedColumns: string[] = ['nombreusuario', 'activo', 'nombrereal', 'tipousuario', 'actions'];
  dataSource: MatTableDataSource<GetUsuarioDTO>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() { 

    this.dataSource = new MatTableDataSource(this.pUsuarios);
  }

  ngOnChanges(changes: SimpleChanges): void {
    
    this.dataSource = new MatTableDataSource(this.pUsuarios);
  }

  ngAfterViewInit(): void {

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
  }

  applyFilter(event: Event): void {

    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  addUsuario(): void {

    this.addUsuarioEvent.emit();
  }

  editUsuario(pRow: GetUsuarioDTO): void {
    
    this.editUsuarioEvent.emit(pRow);
  }

  deleteUsuario(pRow: GetUsuarioDTO): void {
    
    this.deleteUsuarioEvent.emit(pRow.nombreusuario);
  }
}
