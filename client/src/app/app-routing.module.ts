import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { InicioComponent } from './components/inicio/inicio.component';

const routes: Routes = [
  { path: '', redirectTo: 'inicio', pathMatch: 'full' },
  { path: 'inicio', component: InicioComponent },
  {
    path: 'usuarios',
    loadChildren: () => import('./modules/usuarios/usuarios.module')
      .then(mod => mod.UsuariosModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
