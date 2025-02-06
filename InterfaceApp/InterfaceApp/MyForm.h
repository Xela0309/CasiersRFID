#pragma once

#include "bdd.hpp"

namespace InterfaceApp {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Description résumée de MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:

		String^ username;
		String^ password;

		MyForm(void)
		{
			BDD bdd;
			if (bdd.connecter() == false)
			{
				MessageBox::Show("Erreur de connexion à la base de données");
				Application::Exit();
			}

			Connexion();

			//
			//TODO: ajoutez ici le code du constructeur
			//
		}

	protected:
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^ button1;
	protected:

	private: System::Windows::Forms::Label^ label1;

	private:
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code

		// Page de connexion

		void Connexion(void)
		{
			// Définir les propriétés du formulaire
			this->Text = "Page de  Connexion";
			this->Width = 300;
			this->Height = 200;

			// Créer les labels
			Label^ labelUsername = gcnew Label();
			labelUsername->Text = "Login:";
			labelUsername->Left = 10;
			labelUsername->Top = 20;
			this->Controls->Add(labelUsername);

			Label^ labelPassword = gcnew Label();
			labelPassword->Text = "Mot de passe:";
			labelPassword->Left = 10;
			labelPassword->Top = 60;
			this->Controls->Add(labelPassword);

			// Créer les champs de texte
			TextBox^ textBoxUsername = gcnew TextBox();
			textBoxUsername->Left = 110;
			textBoxUsername->Top = 20;
			this->Controls->Add(textBoxUsername);

			TextBox^ textBoxPassword = gcnew TextBox();
			textBoxPassword->Left = 110;
			textBoxPassword->Top = 60;
			textBoxPassword->UseSystemPasswordChar = true; // Masquer le texte du mot de passe
			this->Controls->Add(textBoxPassword);

			// Bouton OK
			Button^ buttonOK = gcnew Button();
			buttonOK->Text = "OK";
			buttonOK->Left = 50;
			buttonOK->Top = 100;
			buttonOK->DialogResult = System::Windows::Forms::DialogResult::OK;
			this->AcceptButton = buttonOK;
			this->Controls->Add(buttonOK);

			// Bouton Annuler
			Button^ buttonCancel = gcnew Button();
			buttonCancel->Text = "Annuler";
			buttonCancel->Left = 150;
			buttonCancel->Top = 100;
			buttonCancel->DialogResult = System::Windows::Forms::DialogResult::Cancel;
			this->CancelButton = buttonCancel;
			this->Controls->Add(buttonCancel);

			// Gestionnaire d'événements pour le bouton OK
			buttonOK->Click += gcnew EventHandler(this, &MyForm::ConnexionClick);
			buttonCancel->Click += gcnew EventHandler(this, &MyForm::CancelClick);

		}

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		void InitializeComponent(void)
		{
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(29, 209);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 0;
			this->button1->Text = L"button1";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::button1_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(26, 31);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(263, 13);
			this->label1->TabIndex = 2;
			this->label1->Text = L"Veuillez rentrez votre login ainsi que votre mot de pase";
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(712, 432);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->button1);
			this->Name = L"MyForm";
			this->Text = L"Interface";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
		// Ne pas tooucher pour le moment 
#pragma endregion
	private: System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) 
	{}

    //---------------------------- Code de la page de connexion ----------------------------//


	private: System::Void ConnexionClick(Object^ sender, EventArgs^ e)
	{
		
		if (this->Controls[1]->Text == "" || this->Controls[2]->Text == "" )
		{
			MessageBox::Show("Veuillez rentrez votre login ainsi que votre mot de pase");
		}
		else
		{
			
			
			MessageBox::Show("Bienvenue " + this->Controls[2]->Text);
			// Récupérer les valeurs des champs de texte
			this->username = this->Controls[2]->Text;
			this->password = this->Controls[3]->Text;
			
			// Effacer le élements de la page de connexion
			this->Controls->Clear();

			// Créer les éléments de la page principale
			InitializeComponent();

		}

	}

	private: System::Void CancelClick(Object^ sender, EventArgs^ e)
	{
		// Fermer le formulaire
		Application::Exit();
	}

	//---------------------------- Code de l'interface graphique ----------------------------//



	private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) 
	{



	}

};
}
