import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuariosRoutingModule } from './usuarios-routing.module';

import { MaterialModule } from '../../shared/modules/material.module';
import { PipesModule } from '../../shared/modules/pipes.module';

import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { TableComponent } from './components/table/table.component';
import { DeleteDialogComponent } from './components/delete-dialog/delete-dialog.component';
import { AddDialogComponent } from './components/add-dialog/add-dialog.component';
import { EditDialogComponent } from './components/edit-dialog/edit-dialog.component';


@NgModule({
  declarations: [
    UsuariosComponent,
    TableComponent,
    DeleteDialogComponent,
    AddDialogComponent,
    EditDialogComponent
  ],
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    MaterialModule,
    PipesModule
  ]
})
export class UsuariosModule { }
