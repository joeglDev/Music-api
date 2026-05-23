// Basic auth proof of concept. Would need to be expanded to retrieve users from DB and verify hashed passwords

export const handleAuth = (username: string, password: string) => {
  return username === "test" && password === "password";
};
