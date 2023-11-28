import { CreateUpdateComponent } from './CRUD/Formulario/CreateUpdate/CreateUpdate.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListarDataComponent } from './CRUD/listar/ListarData/ListarData.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { PerfilUserComponent } from './perfil-user/perfil-user.component';

@NgModule({
  declarations: [			
    AppComponent,
    ListarDataComponent,
    CreateUpdateComponent,
      LoginComponent,
      RegisterComponent,
      PerfilUserComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
