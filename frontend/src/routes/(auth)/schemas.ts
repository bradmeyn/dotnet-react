import { z } from "zod";
export const registerSchema = z
  .object({
    email: z.string().email("Invalid email address"),
    businessName: z
      .string()
      .min(2, "Business name must be at least 2 characters"),
    firstName: z.string().min(2, "First name must be at least 2 characters"),
    lastName: z.string().min(2, "Last name must be at least 2 characters"),
    password: z.string().min(8, "Password must be at least 8 characters"),
    confirmPassword: z.string(),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Passwords don't match",
    path: ["confirmPassword"],
  });
