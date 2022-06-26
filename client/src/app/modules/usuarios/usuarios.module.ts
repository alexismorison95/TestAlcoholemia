import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { UsuariosRoutingModule } from './usuarios-routing.module';

import { MaterialModule } from '../../shared/modules/material.module';
import { PipesModule } from '../../shared/modules/pipes.module';

import { UsuariosComponent } from './usuarios.component';
import { TableComponent } from './components/usuarios/table/table.component';
import { TableComponent as TipousuarioTableComponent } from './components/tipo-usuarios/table/table.component';
import { DeleteDialogComponent } from './components/usuarios/delete-dialog/delete-dialog.component';
import { AddDialogComponent } from './components/usuarios/add-dialog/add-dialog.component';
import { EditDialogComponent } from './components/usuarios/edit-dialog/edit-dialog.component';
import { UsuariosTabComponent } from './pages/usuarios-tab/usuarios-tab.component';
import { TipoUsuariosTabComponent } from './pages/tipo-usuarios-tab/tipo-usuarios-tab.component';


@NgModule({
  declarations: [
    UsuariosComponent,
    TableComponent,
    DeleteDialogComponent,
    AddDialogComponent,
    EditDialogComponent,
    UsuariosTabComponent,
    TipoUsuariosTabComponent,
    TipousuarioTableComponent
  ],
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    MaterialModule,
    PipesModule,
    ReactiveFormsModule
  ]
})
export class UsuariosModule { }
