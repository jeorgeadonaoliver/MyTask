import { UserEntity } from "../entities/user-entity";

export interface IUserRepository {
    createUsers(data: UserEntity): Promise<boolean>;
};
