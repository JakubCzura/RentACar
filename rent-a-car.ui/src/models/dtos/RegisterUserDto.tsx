export class RegisterUserDto {
    public name: string;
    public surname: string;
    public email: string;
    public password: string;
    public phoneNumber: string;
  
    constructor(name: string, surname: string, email: string, password: string, phoneNumber: string) {
      this.name = name;
      this.surname = surname;
      this.email = email;
      this.password = password;
      this.phoneNumber = phoneNumber;
    }
  }