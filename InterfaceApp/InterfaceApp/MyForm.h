#pragma once

#include "bdd.hpp"
#include "Crypt.hpp"
#include <string>
#include <msclr\marshal_cppstd.h>

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


	private: System::Windows::Forms::Label^ login;
	public:

	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::ListBox^ listeAffectation;
	private: System::Windows::Forms::Label^ textListAffectation;
	private: System::Windows::Forms::Button^ Raffraichir;
	private: System::Windows::Forms::Button^ Association;
	private: System::Windows::Forms::ComboBox^ cbCasier;
	private: System::Windows::Forms::ComboBox^ cbVisiteur;
	private: System::Windows::Forms::ComboBox^ cdTag;
	private: System::Windows::Forms::DateTimePicker^ dateDeb;
	private: System::Windows::Forms::DateTimePicker^ dateFin;


	public:
		
	private: System::Windows::Forms::Button^ ajoutUtilisateur;
	private: System::Windows::Forms::Button^ ajoutTag;
	private: System::Windows::Forms::Button^ ajoutVisiteur;
	private: System::Windows::Forms::Button^ suppressionVisiteur;
	private: System::Windows::Forms::Button^ supprimeraffectation;
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::TextBox^ tBNom;
	private: System::Windows::Forms::TextBox^ tBPrenom;
	private: System::Windows::Forms::TextBox^ tBPi;


	private: System::Windows::Forms::TextBox^ tBCompagnie;

	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::Label^ label6;
	private: System::Windows::Forms::Button^ ajoutUtilisateu;
	private: System::Windows::Forms::Button^ retour;


	public:

		BDD* bdd = new BDD();
	private: System::Windows::Forms::Button^ button1;
	private: System::Windows::Forms::ComboBox^ cbRole;


	private: System::Windows::Forms::Label^ label7;
	private: System::Windows::Forms::Label^ label8;
	private: System::Windows::Forms::Label^ label9;
	private: System::Windows::Forms::Label^ label10;
	private: System::Windows::Forms::Button^ button2;
	private: System::Windows::Forms::TextBox^ tbUNom;
	private: System::Windows::Forms::TextBox^ tbUPassword;


	public:
		Crypt* crypt = new Crypt("CryptageApplication");
		
		MyForm(void)
		{

			if (bdd->connecter() == false)
			{
				MessageBox::Show("Erreur de connexion à la base de données");
				Application::Exit();
			}

		
			Connexion();
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

	protected:



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

		void Admin()
		{
			this->login = (gcnew System::Windows::Forms::Label());
			this->listeAffectation = (gcnew System::Windows::Forms::ListBox());
			this->textListAffectation = (gcnew System::Windows::Forms::Label());
			this->Raffraichir = (gcnew System::Windows::Forms::Button());
			this->Association = (gcnew System::Windows::Forms::Button());
			this->cbCasier = (gcnew System::Windows::Forms::ComboBox());
			this->cbVisiteur = (gcnew System::Windows::Forms::ComboBox());
			this->cdTag = (gcnew System::Windows::Forms::ComboBox());
			this->dateDeb = (gcnew System::Windows::Forms::DateTimePicker());
			this->dateFin = (gcnew System::Windows::Forms::DateTimePicker());
			this->ajoutUtilisateur = (gcnew System::Windows::Forms::Button());
			this->ajoutTag = (gcnew System::Windows::Forms::Button());
			this->ajoutVisiteur = (gcnew System::Windows::Forms::Button());
			this->suppressionVisiteur = (gcnew System::Windows::Forms::Button());
			this->supprimeraffectation = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// login
			// 
			this->login->AutoSize = true;
			this->login->Location = System::Drawing::Point(651, 0);
			this->login->Name = L"login";
			this->login->Size = System::Drawing::Size(53, 13);
			this->login->TabIndex = 0;
			this->login->Text = L"username";
			// 
			// listeAffectation
			// 
			this->listeAffectation->FormattingEnabled = true;
			this->listeAffectation->Location = System::Drawing::Point(60, 139);
			this->listeAffectation->Name = L"listeAffectation";
			this->listeAffectation->Size = System::Drawing::Size(126, 56);
			this->listeAffectation->TabIndex = 3;
			this->listeAffectation->SelectedIndexChanged += gcnew System::EventHandler(this, &MyForm::listeAffectation_SelectedIndexChanged);
			// 
			// textListAffectation
			// 
			this->textListAffectation->AutoSize = true;
			this->textListAffectation->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->textListAffectation->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold,
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
			this->textListAffectation->Location = System::Drawing::Point(30, 100);
			this->textListAffectation->Name = L"textListAffectation";
			this->textListAffectation->Size = System::Drawing::Size(174, 15);
			this->textListAffectation->TabIndex = 2;
			this->textListAffectation->Text = L"Casiers en cours d\'utiilisation";
			// 
			// Raffraichir
			// 
			this->Raffraichir->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->Raffraichir->Location = System::Drawing::Point(74, 219);
			this->Raffraichir->Name = L"Raffraichir";
			this->Raffraichir->Size = System::Drawing::Size(97, 24);
			this->Raffraichir->TabIndex = 4;
			this->Raffraichir->Text = L"Raffraichir";
			this->Raffraichir->UseVisualStyleBackColor = true;
			this->Raffraichir->Click += gcnew System::EventHandler(this, &MyForm::Refresh_Click_1);
			// 
			// Association
			// 
			this->Association->Location = System::Drawing::Point(385, 203);
			this->Association->Name = L"Association";
			this->Association->Size = System::Drawing::Size(75, 23);
			this->Association->TabIndex = 5;
			this->Association->Text = L"Affectation";
			this->Association->UseVisualStyleBackColor = true;
			this->Association->Click += gcnew System::EventHandler(this, &MyForm::Association_Click);
			// 
			// cbCasier
			// 
			this->cbCasier->FormattingEnabled = true;
			this->cbCasier->Location = System::Drawing::Point(511, 115);
			this->cbCasier->Name = L"cbCasier";
			this->cbCasier->Size = System::Drawing::Size(121, 21);
			this->cbCasier->TabIndex = 6;
			// 
			// cbVisiteur
			// 
			this->cbVisiteur->FormattingEnabled = true;
			this->cbVisiteur->Location = System::Drawing::Point(230, 115);
			this->cbVisiteur->Name = L"cbVisiteur";
			this->cbVisiteur->Size = System::Drawing::Size(121, 21);
			this->cbVisiteur->TabIndex = 7;
			// 
			// cdTag
			// 
			this->cdTag->FormattingEnabled = true;
			this->cdTag->Location = System::Drawing::Point(371, 115);
			this->cdTag->Name = L"cdTag";
			this->cdTag->Size = System::Drawing::Size(121, 21);
			this->cdTag->TabIndex = 8;
			// 
			// dateDeb
			// 
			this->dateDeb->Location = System::Drawing::Point(230, 166);
			this->dateDeb->Name = L"dateDeb";
			this->dateDeb->Size = System::Drawing::Size(184, 20);
			this->dateDeb->TabIndex = 9;
			// 
			// dateFin
			// 
			this->dateFin->Location = System::Drawing::Point(432, 166);
			this->dateFin->Name = L"dateFin";
			this->dateFin->Size = System::Drawing::Size(200, 20);
			this->dateFin->TabIndex = 10;
			// 
			// ajoutUtilisateur
			// 
			this->ajoutUtilisateur->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9.75F, System::Drawing::FontStyle::Regular,
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
			this->ajoutUtilisateur->Location = System::Drawing::Point(25, 29);
			this->ajoutUtilisateur->Name = L"ajoutUtilisateur";
			this->ajoutUtilisateur->Size = System::Drawing::Size(97, 41);
			this->ajoutUtilisateur->TabIndex = 11;
			this->ajoutUtilisateur->Text = L"Créer utilisateur";
			this->ajoutUtilisateur->UseVisualStyleBackColor = true;
			this->ajoutUtilisateur->Click += gcnew System::EventHandler(this, &MyForm::LienAjoutUtilisateur_Click);
			// 
			// ajoutTag
			// 
			this->ajoutTag->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->ajoutTag->Location = System::Drawing::Point(570, 29);
			this->ajoutTag->Name = L"ajoutTag";
			this->ajoutTag->Size = System::Drawing::Size(97, 41);
			this->ajoutTag->TabIndex = 12;
			this->ajoutTag->Text = L"Ajout Tag";
			this->ajoutTag->UseVisualStyleBackColor = true;
			this->ajoutTag->Click += gcnew System::EventHandler(this, &MyForm::ajoutTag_Click);
			// 
			// ajoutVisiteur
			// 
			this->ajoutVisiteur->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->ajoutVisiteur->Location = System::Drawing::Point(157, 29);
			this->ajoutVisiteur->Name = L"ajoutVisiteur";
			this->ajoutVisiteur->Size = System::Drawing::Size(97, 41);
			this->ajoutVisiteur->TabIndex = 13;
			this->ajoutVisiteur->Text = L"Créer Visiteur";
			this->ajoutVisiteur->UseVisualStyleBackColor = true;
			this->ajoutVisiteur->Click += gcnew System::EventHandler(this, &MyForm::LienAjoutVisiteur_Click);
			// 
			// suppressionVisiteur
			// 
			this->suppressionVisiteur->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9.75F, System::Drawing::FontStyle::Regular,
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
			this->suppressionVisiteur->Location = System::Drawing::Point(292, 29);
			this->suppressionVisiteur->Name = L"suppressionVisiteur";
			this->suppressionVisiteur->Size = System::Drawing::Size(97, 41);
			this->suppressionVisiteur->TabIndex = 14;
			this->suppressionVisiteur->Text = L"Supprimer Visiteur";
			this->suppressionVisiteur->UseVisualStyleBackColor = true;
			this->suppressionVisiteur->Click += gcnew System::EventHandler(this, &MyForm::LienSuppressionVisiteur_Click);
			// 
			// supprimeraffectation
			// 
			this->supprimeraffectation->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9.75F, System::Drawing::FontStyle::Regular,
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
			this->supprimeraffectation->Location = System::Drawing::Point(437, 29);
			this->supprimeraffectation->Name = L"supprimeraffectation";
			this->supprimeraffectation->Size = System::Drawing::Size(97, 41);
			this->supprimeraffectation->TabIndex = 15;
			this->supprimeraffectation->Text = L"Supprimer Affectation";
			this->supprimeraffectation->UseVisualStyleBackColor = true;
			this->supprimeraffectation->Click += gcnew System::EventHandler(this, &MyForm::LienSupprimeraffectation_Click);
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::ScrollBar;
			this->ClientSize = System::Drawing::Size(705, 287);
			this->Controls->Add(this->supprimeraffectation);
			this->Controls->Add(this->suppressionVisiteur);
			this->Controls->Add(this->ajoutVisiteur);
			this->Controls->Add(this->ajoutTag);
			this->Controls->Add(this->ajoutUtilisateur);
			this->Controls->Add(this->dateFin);
			this->Controls->Add(this->dateDeb);
			this->Controls->Add(this->cdTag);
			this->Controls->Add(this->cbVisiteur);
			this->Controls->Add(this->cbCasier);
			this->Controls->Add(this->Association);
			this->Controls->Add(this->Raffraichir);
			this->Controls->Add(this->textListAffectation);
			this->Controls->Add(this->listeAffectation);
			this->Controls->Add(this->login);
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->ResumeLayout(false);
			this->PerformLayout();
			this->Name = L"MyForm";
			this->Text = L"Interface";
		}

		void PageAjoutUtilisateur()
		{
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->cbRole = (gcnew System::Windows::Forms::ComboBox());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->label8 = (gcnew System::Windows::Forms::Label());
			this->label9 = (gcnew System::Windows::Forms::Label());
			this->label10 = (gcnew System::Windows::Forms::Label());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->tbUNom = (gcnew System::Windows::Forms::TextBox());
			this->tbUPassword = (gcnew System::Windows::Forms::TextBox());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(89, 235);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Créer";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::ajoutUtilisateur_Click);
			// 
			// cbRole
			// 
			this->cbRole->FormattingEnabled = true;
			this->cbRole->Location = System::Drawing::Point(129, 181);
			this->cbRole->Name = L"cbRole";
			this->cbRole->Size = System::Drawing::Size(135, 21);
			this->cbRole->TabIndex = 1;
			// 
			// label7
			// 
			this->label7->AutoSize = true;
			this->label7->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label7->Location = System::Drawing::Point(12, 103);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(46, 13);
			this->label7->TabIndex = 2;
			this->label7->Text = L"Login :";
			// 
			// label8
			// 
			this->label8->AutoSize = true;
			this->label8->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label8->Location = System::Drawing::Point(12, 143);
			this->label8->Name = L"label8";
			this->label8->Size = System::Drawing::Size(69, 13);
			this->label8->TabIndex = 3;
			this->label8->Text = L"Password :";
			// 
			// label9
			// 
			this->label9->AutoSize = true;
			this->label9->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label9->Location = System::Drawing::Point(12, 184);
			this->label9->Name = L"label9";
			this->label9->Size = System::Drawing::Size(41, 13);
			this->label9->TabIndex = 4;
			this->label9->Text = L"Rôle :";
			// 
			// label10
			// 
			this->label10->AutoSize = true;
			this->label10->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label10->Location = System::Drawing::Point(64, 52);
			this->label10->Name = L"label10";
			this->label10->Size = System::Drawing::Size(133, 13);
			this->label10->TabIndex = 5;
			this->label10->Text = L"Ajout d\'un Utilisateur :";
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(-1, -1);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(39, 29);
			this->button2->TabIndex = 6;
			this->button2->Text = L"<";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &MyForm::retour_Click);
			// 
			// tbUNom
			// 
			this->tbUNom->Location = System::Drawing::Point(129, 103);
			this->tbUNom->Name = L"tbUNom";
			this->tbUNom->Size = System::Drawing::Size(135, 20);
			this->tbUNom->TabIndex = 7;
			// 
			// tbUPassword
			// 
			this->tbUPassword->Location = System::Drawing::Point(129, 140);
			this->tbUPassword->Name = L"tbUPassword";
			this->tbUPassword->Size = System::Drawing::Size(135, 20);
			this->tbUPassword->TabIndex = 8;
			// 
			// MyForm
			// 
			this->ClientSize = System::Drawing::Size(381, 341);
			this->Controls->Add(this->tbUPassword);
			this->Controls->Add(this->tbUNom);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->label10);
			this->Controls->Add(this->label9);
			this->Controls->Add(this->label8);
			this->Controls->Add(this->label7);
			this->Controls->Add(this->cbRole);
			this->Controls->Add(this->button1);
			this->Name = L"MyForm";
			this->Text = L"Creation d'utilisateur";
			this->ResumeLayout(false);
			this->PerformLayout();

		}

		void PageAjoutTag()
		{

		}

		void PageAjoutVisiteur()
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->tBNom = (gcnew System::Windows::Forms::TextBox());
			this->tBPrenom = (gcnew System::Windows::Forms::TextBox());
			this->tBPi = (gcnew System::Windows::Forms::TextBox());
			this->tBCompagnie = (gcnew System::Windows::Forms::TextBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->ajoutUtilisateu = (gcnew System::Windows::Forms::Button());
			this->retour = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label1->Location = System::Drawing::Point(11, 38);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(118, 13);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Ajout d\'un Visiteur :";
			// 
			// tBNom
			// 
			this->tBNom->Location = System::Drawing::Point(169, 76);
			this->tBNom->Name = L"tBNom";
			this->tBNom->Size = System::Drawing::Size(157, 20);
			this->tBNom->TabIndex = 1;
			// 
			// tBPrenom
			// 
			this->tBPrenom->Location = System::Drawing::Point(169, 111);
			this->tBPrenom->Name = L"tBPrenom";
			this->tBPrenom->Size = System::Drawing::Size(157, 20);
			this->tBPrenom->TabIndex = 3;
			// 
			// tBPi
			// 
			this->tBPi->Location = System::Drawing::Point(169, 189);
			this->tBPi->Name = L"tBPi";
			this->tBPi->Size = System::Drawing::Size(157, 20);
			this->tBPi->TabIndex = 4;
			// 
			// tBCompagnie
			// 
			this->tBCompagnie->Location = System::Drawing::Point(169, 151);
			this->tBCompagnie->Name = L"tBCompagnie";
			this->tBCompagnie->Size = System::Drawing::Size(157, 20);
			this->tBCompagnie->TabIndex = 5;
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label3->Location = System::Drawing::Point(11, 79);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(40, 13);
			this->label3->TabIndex = 6;
			this->label3->Text = L"Nom :";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label4->Location = System::Drawing::Point(11, 114);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(57, 13);
			this->label4->TabIndex = 7;
			this->label4->Text = L"Prénom :";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label5->Location = System::Drawing::Point(11, 154);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(77, 13);
			this->label5->TabIndex = 8;
			this->label5->Text = L"Compagnie :";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label6->Location = System::Drawing::Point(11, 192);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(152, 13);
			this->label6->TabIndex = 9;
			this->label6->Text = L"Plaque d\'immatriculation :";
			// 
			// ajoutUtilisateu
			// 
			this->ajoutUtilisateu->Location = System::Drawing::Point(379, 125);
			this->ajoutUtilisateu->Name = L"ajoutUtilisateu";
			this->ajoutUtilisateu->Size = System::Drawing::Size(75, 23);
			this->ajoutUtilisateu->TabIndex = 10;
			this->ajoutUtilisateu->Text = L"Ajouter";
			this->ajoutUtilisateu->UseVisualStyleBackColor = true;
			this->ajoutUtilisateu->Click += gcnew System::EventHandler(this, &MyForm::ajoutVisiteur_Click);
			// 
			// retour
			// 
			this->retour->Location = System::Drawing::Point(-1, -1);
			this->retour->Name = L"retour";
			this->retour->Size = System::Drawing::Size(34, 27);
			this->retour->TabIndex = 11;
			this->retour->Text = L"<";
			this->retour->UseVisualStyleBackColor = true;
			this->retour->Click += gcnew System::EventHandler(this, &MyForm::retour_Click);
			// 
			// MyForm
			// 
			this->ClientSize = System::Drawing::Size(504, 220);
			this->Controls->Add(this->retour);
			this->Controls->Add(this->ajoutUtilisateu);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->tBCompagnie);
			this->Controls->Add(this->tBPi);
			this->Controls->Add(this->tBPrenom);
			this->Controls->Add(this->tBNom);
			this->Controls->Add(this->label1);
			this->Name = L"MyForm";
			this->Text = L"Ajout Visiteur";
			this->ResumeLayout(false);
			this->PerformLayout();
		}

		void PageSuppressionVisiteur()
		{

		}

		void PageSuppressionAffectation()
		{

		}

		void Utilisateur()
		{

			this->login = (gcnew System::Windows::Forms::Label());
			this->listeAffectation = (gcnew System::Windows::Forms::ListBox());
			this->textListAffectation = (gcnew System::Windows::Forms::Label());
			this->Raffraichir = (gcnew System::Windows::Forms::Button());
			this->Association = (gcnew System::Windows::Forms::Button());
			this->cbCasier = (gcnew System::Windows::Forms::ComboBox());
			this->cbVisiteur = (gcnew System::Windows::Forms::ComboBox());
			this->cdTag = (gcnew System::Windows::Forms::ComboBox());
			this->dateDeb = (gcnew System::Windows::Forms::DateTimePicker());
			this->dateFin = (gcnew System::Windows::Forms::DateTimePicker());
			this->SuspendLayout();
			// 
			// login
			// 
			this->login->AutoSize = true;
			this->login->Location = System::Drawing::Point(651, 0);
			this->login->Name = L"login";
			this->login->Size = System::Drawing::Size(53, 13);
			this->login->TabIndex = 0;
			this->login->Text = L"username";
			// 
			// listeAffectation
			// 
			this->listeAffectation->FormattingEnabled = true;
			this->listeAffectation->Location = System::Drawing::Point(59, 92);
			this->listeAffectation->Name = L"listeAffectation";
			this->listeAffectation->Size = System::Drawing::Size(110, 56);
			this->listeAffectation->TabIndex = 3;
			this->listeAffectation->SelectedIndexChanged += gcnew System::EventHandler(this, &MyForm::listeAffectation_SelectedIndexChanged);
			// 
			// textListAffectation
			// 
			this->textListAffectation->AutoSize = true;
			this->textListAffectation->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
			this->textListAffectation->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold,
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
			this->textListAffectation->Location = System::Drawing::Point(29, 53);
			this->textListAffectation->Name = L"textListAffectation";
			this->textListAffectation->Size = System::Drawing::Size(174, 15);
			this->textListAffectation->TabIndex = 2;
			this->textListAffectation->Text = L"Casiers en cours d\'utiilisation";
			// 
			// Raffraichir
			// 
			this->Raffraichir->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->Raffraichir->Location = System::Drawing::Point(305, 204);
			this->Raffraichir->Name = L"Raffraichir";
			this->Raffraichir->Size = System::Drawing::Size(97, 24);
			this->Raffraichir->TabIndex = 4;
			this->Raffraichir->Text = L"Raffraichir";
			this->Raffraichir->UseVisualStyleBackColor = true;
			this->Raffraichir->Click += gcnew System::EventHandler(this, &MyForm::Refresh_Click_1);
			// 
			// Association
			// 
			this->Association->Location = System::Drawing::Point(436, 156);
			this->Association->Name = L"Association";
			this->Association->Size = System::Drawing::Size(75, 23);
			this->Association->TabIndex = 5;
			this->Association->Text = L"Affectation";
			this->Association->UseVisualStyleBackColor = true;
			this->Association->Click += gcnew System::EventHandler(this, &MyForm::Association_Click);
			// 
			// cbCasier
			// 
			this->cbCasier->FormattingEnabled = true;
			this->cbCasier->Location = System::Drawing::Point(562, 68);
			this->cbCasier->Name = L"cbCasier";
			this->cbCasier->Size = System::Drawing::Size(121, 21);
			this->cbCasier->TabIndex = 6;
			// 
			// cbVisiteur
			// 
			this->cbVisiteur->FormattingEnabled = true;
			this->cbVisiteur->Location = System::Drawing::Point(281, 68);
			this->cbVisiteur->Name = L"cbVisiteur";
			this->cbVisiteur->Size = System::Drawing::Size(121, 21);
			this->cbVisiteur->TabIndex = 7;
			// 
			// cdTag
			// 
			this->cdTag->FormattingEnabled = true;
			this->cdTag->Location = System::Drawing::Point(422, 68);
			this->cdTag->Name = L"cdTag";
			this->cdTag->Size = System::Drawing::Size(121, 21);
			this->cdTag->TabIndex = 8;
			// 
			// dateDeb
			// 
			this->dateDeb->Location = System::Drawing::Point(281, 119);
			this->dateDeb->Name = L"dateDeb";
			this->dateDeb->Size = System::Drawing::Size(184, 20);
			this->dateDeb->TabIndex = 9;
			// 
			// dateFin
			// 
			this->dateFin->Location = System::Drawing::Point(483, 119);
			this->dateFin->Name = L"dateFin";
			this->dateFin->Size = System::Drawing::Size(200, 20);
			this->dateFin->TabIndex = 10;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::ScrollBar;
			this->ClientSize = System::Drawing::Size(705, 240);
			this->Controls->Add(this->dateFin);
			this->Controls->Add(this->dateDeb);
			this->Controls->Add(this->cdTag);
			this->Controls->Add(this->cbVisiteur);
			this->Controls->Add(this->cbCasier);
			this->Controls->Add(this->Association);
			this->Controls->Add(this->Raffraichir);
			this->Controls->Add(this->textListAffectation);
			this->Controls->Add(this->listeAffectation);
			this->Controls->Add(this->login);
			this->Name = L"MyForm";
			this->Text = L"Interface";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->ResumeLayout(false);
			this->PerformLayout();
		}

		//********************************************************************************************************************//
		
		void InitializeComponent(void)
		{

		}

		//********************************************************************************************************************//
#pragma endregion
	private: System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) 
	{
	}

    //---------------------------- Code de la page de connexion ----------------------------//

	// Changement de l'username
	private: System::Void UseUsername()
	{
		this->login->Text = username;
    }

	private: System::Void ConnexionClick(Object^ sender, EventArgs^ e)
	{
		if (this->Controls[2]->Text == "" || this->Controls[3]->Text == "" )
		{
			MessageBox::Show("Veuillez rentrez votre login ainsi que votre mot de pase");
		}
		else
		{
			// Récupérer les informations de connexion
			msclr::interop::marshal_context context; // Permet la conversion

			std::string log = context.marshal_as<std::string>(this->Controls[2]->Text);
			std::string pass = context.marshal_as<std::string>(this->Controls[3]->Text);

			// Verifier les logs de la connexion à la base de données 

			if (bdd->estUnUtilisateurAutorise(crypt->crypter(log), crypt->crypter(pass)) == false)
			{
				MessageBox::Show("Erreur de connexion à la base de données : Mot de passe ou Login faux");
			}
			else
			{
				if (bdd->estAdministrateur(crypt->crypter(log), crypt->crypter(pass)) == true)
				{

					// Stocker les informations de connexion
					username = this->Controls[2]->Text;
					password = this->Controls[3]->Text;

					// Effacer le élements de la page de connexion
					this->Controls->Clear();

					// Créer les éléments de la page principale
					Admin();
					afficherAffectations();
					UseUsername();
					afficherVisiteur();
					afficherCasier();
					afficherTag();
				}
				else
				{
					// Stocker les informations de connexion
					username = this->Controls[2]->Text;
					password = this->Controls[3]->Text;

					// Effacer le élements de la page de connexion
					this->Controls->Clear();

					// Créer les éléments de la page principale
					Utilisateur();
					afficherAffectations();
					UseUsername();
					afficherVisiteur();
					afficherCasier();
					afficherTag();
				}


			}
		}
	}

	private: System::Void CancelClick(Object^ sender, EventArgs^ e)
	{
		// Fermer le formulaire
		Application::Exit();
	}

	//---------------------------- Code de l'affichage des affectations ----------------------------//

	//Afficher les affectations
	private: System::Void afficherAffectations()
	{
		// Récupérer la liste des affectations
		std::vector<std::string> affectations = bdd->listeAffectation();

		//Ajouter "Casier n°" devant le numéro de chaque affectation


		// Afficher les affectations
		for (int i = 0; i < affectations.size(); i++)
		{
			this->listeAffectation->Items->Add(gcnew String(affectations[i].c_str()));
		}
	}

	private: System::Void listeAffectation_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e) 
	{
		// Récupérer l'index de l'élément sélectionné
		int index = this->listeAffectation->SelectedIndex;

		// Récupérer le nom de l'affectation
		msclr::interop::marshal_context context; // Permet la conversion
		std::string affectation = context.marshal_as<std::string>(this->listeAffectation->Items[index]->ToString());

		// Récupérer les informations de l'affectation
		std::vector<std::string> infos = bdd->infosAffectation(affectation);

		// Afficher les informations de l'affectation
		String^ message = "Informations de l'affectation :\n\n";
		message += "Tag utilisé : " + gcnew String(infos[0].c_str()) + "\n";
		message += "Prénom : " + gcnew String(infos[2].c_str()) + "\t";
		message += "Nom : " + gcnew String(infos[1].c_str()) + "\n\n";
		message += "Compagnie : " + gcnew String(infos[3].c_str()) + "\n";
		message += "Numéro de la plaque : " + gcnew String(infos[4].c_str()) + "\n\n";
		message += "Date de début : " + gcnew String(infos[6].c_str()) + "\n";
		message += "Date de fin : " + gcnew String(infos[7].c_str()) + "\n";
		MessageBox::Show(message);
	}

	private: System::Void Refresh_Click_1(System::Object^ sender, System::EventArgs^ e) 
	{
		// Effacer les affectations actuelles
		this->listeAffectation->Items->Clear();
		afficherAffectations();

		// Effacer les éléments des ComboBox
		this->cbVisiteur->Items->Clear();
		this->cbCasier->Items->Clear();
		this->cdTag->Items->Clear();

		// Afficher les nouveaux éléments
		afficherVisiteur();
		afficherCasier();
		afficherTag();
	}
	//---------------------------- Code de la création d'affectation ----------------------------//

	private: std::string extractDate(std:: string date)
	{
		std::string annee , mois , jour;
		annee = date.substr(6, 4);
		mois = date.substr(3, 2);
		jour = date.substr(0, 2);


		return annee + "-" + mois + "-" + jour;
	}
	
	private: System::Void afficherVisiteur()
	{
		// Récupérer la liste des Visiteurs non affectés
		std::vector<std::string> visiteurs = bdd->listeVisiteurNonAffecter();

		// Ajouter les visiteurs non affectés
		for (int i = 0; i < visiteurs.size(); i++)
		{
			this->cbVisiteur->Items->Add(gcnew String(crypt->decrypt(visiteurs[i]).c_str()));
		}
	}

	private: System::Void afficherCasier()
	{
		// Récupérer la liste des Casiers
		std::vector<std::string> casiers = bdd->listeCasierNonAffecter();

		// Ajouter les casiers
		for (int i = 0; i < casiers.size(); i++)
		{
			this->cbCasier->Items->Add(gcnew String(casiers[i].c_str()));
		}
	}

	private: System::Void afficherTag()
	{
		// Récupérer la liste des Tags
		std::vector<std::string> tags = bdd->listeTagNonAffecter();

		// Ajouter les tags
		for (int i = 0; i < tags.size(); i++)
		{
																																																																																	
			this->cdTag->Items->Add(gcnew String(tags[i].c_str()));
		}
	}


	private: System::Void Association_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		// Récupérer les informations de l'affectation
		msclr::interop::marshal_context context; // Permet la conversion
		std::string visiteur = context.marshal_as<std::string>(this->cbVisiteur->Text);
		std::string casier = context.marshal_as<std::string>(this->cbCasier->Text);
		std::string tag = context.marshal_as<std::string>(this->cdTag->Text);
		std::string dateDebut = context.marshal_as<std::string>(this->dateDeb->Value.ToString());
		std::string dateFin = context.marshal_as<std::string>(this->dateFin->Value.ToString());

		dateDebut = extractDate(dateDebut);
		dateFin = extractDate(dateFin);

		// Vérifier que les informations sont correctes
		if (visiteur == "" || casier == "" || tag == "" || dateDebut == "" || dateFin == "" || dateDebut == dateFin)
		{
			MessageBox::Show("Veuillez sélectionner un visiteur, un casier et un tag");
		}
		else
		{
			if (bdd->verificationAffectationExistente(visiteur, casier, tag) == false)
			{
				MessageBox::Show("Un élement est déja utilisé");
			}
			else
			{
				// Ajouter l'affectation
				bdd->ajouterAffectation(visiteur, casier, tag, dateDebut, dateFin);

				// Actualiser les éléments
				this->listeAffectation->Items->Clear();
				afficherAffectations();
				this->cbVisiteur->Items->Clear();
				this->cbCasier->Items->Clear();
				this->cdTag->Items->Clear();
				afficherVisiteur();
				afficherCasier();
				afficherTag();
			}
		}
	}

	//---------------------------- Code de la partie Admin ----------------------------//

	private: System::Void LienAjoutUtilisateur_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		// Effacer le formulaire actuel
		this->Controls->Clear();

		// Créer le formulaire d'ajout d'utilisateur
		PageAjoutUtilisateur();
		choixRole();
	}

	private: System::Void LienAjoutTag_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		// Effacer le formulaire actuel
		this->Controls->Clear();

		// Créer le formulaire d'ajout de tag
		PageAjoutTag();
	}

	private: System::Void LienAjoutVisiteur_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		// Effacer le formulaire actuel
		this->Controls->Clear();

		// Créer le formulaire d'ajout de visiteur
		PageAjoutVisiteur();
	}

	private: System::Void LienSuppressionVisiteur_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		// Effacer le formulaire actuel
		this->Controls->Clear();

		// Créer le formulaire de suppression de visiteur
		PageSuppressionVisiteur();
	}

	private: System::Void LienSupprimeraffectation_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		// Effacer le formulaire actuel
		this->Controls->Clear();

		// Créer le formulaire de suppression d'affectation
		PageSuppressionAffectation();
	}

	private: System::Void ajoutUtilisateur_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		String^ nom = this->tbUNom->Text;
		String^ password = this->tbUPassword->Text;
		String^ role = this->cbRole->Text;


		if (nom == "" || password == "" || role == "")
		{
			MessageBox::Show("Veuillez rentrer un nom, un mot de passe et un rôle");
		}
		else
		{
			msclr::interop::marshal_context context; // Permet la conversion
			std::string nomS = context.marshal_as<std::string>(nom);
			std::string passwordS = context.marshal_as<std::string>(password);
			std::string roleS = context.marshal_as<std::string>(role);

			if (bdd->ajouterUtilisateur(crypt->crypter(nomS), crypt->crypter(passwordS), roleS) == false)
			{
				MessageBox::Show("Erreur lors de l'ajout de l'utilisateur");
			}
			else
			{
				MessageBox::Show("Utilisateur ajouté avec succès");
			}
		}

	}

	private: System::Void ajoutTag_Click(System::Object^ sender, System::EventArgs^ e) 
	{
	}

	private: System::Void ajoutVisiteur_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		// Récupérer les informations de l'utilisateur
		String^ nom = this->tBNom->Text;
		String^ prenom = this->tBPrenom->Text;
		String^ compagnie = this->tBCompagnie->Text;
		String^ plaque = this->tBPi->Text;

		// Vérifier que les informations sont correctes
		if (nom == "" || prenom == "" || compagnie == "" || plaque == "")
		{
			MessageBox::Show("Veuillez rentrer un nom, un prénom, une compagnie et une plaque d'immatriculation");
		}
		else
		{
			// Ajouter l'utilisateur
			msclr::interop::marshal_context context; // Permet la conversion
			std::string nomS = context.marshal_as<std::string>(nom);
			std::string prenomS = context.marshal_as<std::string>(prenom);
			std::string compagnieS = context.marshal_as<std::string>(compagnie);
			std::string plaqueS = context.marshal_as<std::string>(plaque);

			if (bdd->ajouterVisiteur(crypt->crypter(nomS), crypt->crypter(prenomS), crypt->crypter(compagnieS), crypt->crypter(plaqueS)) == false)
			{
				MessageBox::Show("Erreur lors de l'ajout de l'utilisateur");
			}
			else
			{
				MessageBox::Show("Utilisateur ajouté avec succès");
			}

		}
	}

	private: System::Void suppressionVisiteur_Click(System::Object^ sender, System::EventArgs^ e) 
	{
	}

	private: System::Void supprimeraffectation_Click(System::Object^ sender, System::EventArgs^ e) 
	{
	}

	private: System::Void retour_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		// Effacer le formulaire actuel
		this->Controls->Clear();

		// Créer le formulaire de connexion
		Admin();
		afficherAffectations();
		UseUsername();
		afficherVisiteur();
		afficherCasier();
		afficherTag();

	}

	private: System::Void choixRole() 
	{
		// Afficher deux role disponible dansl acombo box

		this->cbRole->Items->Add("admin");
		this->cbRole->Items->Add("user");
			
	}

	//---------------------------- Code de l'interface graphique ----------------------------//



};
}
