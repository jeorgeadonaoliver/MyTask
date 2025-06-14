﻿using FluentValidation.Results;

namespace MyTask.Application.Common.Extension;

public static class ValidationResultExtension
{
    public static void CheckValidationResult(this ValidationResult result) {

        if (result.Errors.Any()) {

            var errorMessage = string.Join("; ", result.Errors.Select( o => o.ErrorMessage));
            throw new Exception(errorMessage);
        }
    }
}
