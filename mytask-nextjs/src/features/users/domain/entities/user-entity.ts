export type UserEntity = {
    id: string;
    fullName: string;
    email: string;
    passwordHash: string;
    avatarUrl: string;
    roleId: string;
    createdAt: Date;
    updatedAt: Date;
};