export class RegisterUserDto {
  constructor(
    public name: string,
    public surname: string,
    public email: string,
    public password: string,
    public phoneNumber: string
  ) { }
}