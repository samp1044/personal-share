package at.sampas.personal_share.file.service;

import java.io.InputStream;

public record UploadFileCommand(String user, String fileName, String fileType, InputStream content) {}
